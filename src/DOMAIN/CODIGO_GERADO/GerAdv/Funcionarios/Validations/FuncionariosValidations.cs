#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncionariosValidation
{
    Task<string> ValidateReg(Models.Funcionarios reg, IFuncionariosService service, ICargosReader cargosReader, IFuncaoReader funcaoReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IFuncionariosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IAgendaRepetirService agendarepetirService, IHorasTrabService horastrabService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class FuncionariosValidation : IFuncionariosValidation
{
    public async Task<string> CanDelete(int id, IFuncionariosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IAgendaRepetirService agendarepetirService, IHorasTrabService horastrabService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists0 = await agendaService.Filter(new Filters.FilterAgenda { Funcionario = id }, uri);
        if (agendaExists0 != null && agendaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists1 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Funcionario = id }, uri);
        if (agendafinanceiroExists1 != null && agendafinanceiroExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendaquemExists2 = await agendaquemService.Filter(new Filters.FilterAgendaQuem { Funcionario = id }, uri);
        if (agendaquemExists2 != null && agendaquemExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Quem associados a ele.";
        var agendarepetirExists3 = await agendarepetirService.Filter(new Filters.FilterAgendaRepetir { Funcionario = id }, uri);
        if (agendarepetirExists3 != null && agendarepetirExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Repetir associados a ele.";
        var horastrabExists4 = await horastrabService.Filter(new Filters.FilterHorasTrab { Funcionario = id }, uri);
        if (horastrabExists4 != null && horastrabExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Funcionarios reg, IFuncionariosService service, ICargosReader cargosReader, IFuncaoReader funcaoReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (!string.IsNullOrWhiteSpace(reg.CPF))
        {
            var testaCpf = await IsCpfDuplicado(reg, service, uri);
            if (testaCpf.Item1 && testaCpf.Item2 != null)
            {
                return $"Colaborador ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Colaborador com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
        }

        // Cargos
        if (!reg.Cargo.IsEmptyIDNumber())
        {
            var regCargos = cargosReader.Read(reg.Cargo, oCnn);
            if (regCargos == null || regCargos.Id != reg.Cargo)
            {
                return $"Cargos não encontrado ({regCargos?.Id}).";
            }
        }

        // Funcao
        if (!reg.Funcao.IsEmptyIDNumber())
        {
            var regFuncao = funcaoReader.Read(reg.Funcao, oCnn);
            if (regFuncao == null || regFuncao.Id != reg.Funcao)
            {
                return $"Função não encontrado ({regFuncao?.Id}).";
            }
        }

        // Cidade
        if (!reg.Cidade.IsEmptyIDNumber())
        {
            var regCidade = cidadeReader.Read(reg.Cidade, oCnn);
            if (regCidade == null || regCidade.Id != reg.Cidade)
            {
                return $"Cidade não encontrado ({regCidade?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<(bool, FuncionariosResponseAll? )> IsCpfDuplicado(Models.Funcionarios reg, IFuncionariosService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingFuncionarios = (await service.Filter(new Filters.FilterFuncionarios { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingFuncionarios != null && existingFuncionarios.Id > 0 && existingFuncionarios.Id != reg.Id, existingFuncionarios);
    }
}