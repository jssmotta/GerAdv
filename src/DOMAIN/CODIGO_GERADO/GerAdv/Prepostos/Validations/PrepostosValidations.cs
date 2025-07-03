#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPrepostosValidation
{
    Task<string> ValidateReg(Models.Prepostos reg, IPrepostosService service, IFuncaoReader funcaoReader, ISetorReader setorReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IPrepostosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class PrepostosValidation : IPrepostosValidation
{
    public async Task<string> CanDelete(int id, IPrepostosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IProcessosService processosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists = await agendaService.Filter(new Filters.FilterAgenda { Preposto = id }, uri);
        if (agendaExists != null && agendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Preposto = id }, uri);
        if (agendafinanceiroExists != null && agendafinanceiroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendaquemExists = await agendaquemService.Filter(new Filters.FilterAgendaQuem { Preposto = id }, uri);
        if (agendaquemExists != null && agendaquemExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Quem associados a ele.";
        var processosExists = await processosService.Filter(new Filters.FilterProcessos { Preposto = id }, uri);
        if (processosExists != null && processosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Prepostos reg, IPrepostosService service, IFuncaoReader funcaoReader, ISetorReader setorReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
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
                return $"Prepostos ({testaCpf.Item2.Nome}) com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
            }
            else if (testaCpf.Item1)
            {
                return $"Prepostos com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
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

        // Setor
        if (!reg.Setor.IsEmptyIDNumber())
        {
            var regSetor = setorReader.Read(reg.Setor, oCnn);
            if (regSetor == null || regSetor.Id != reg.Setor)
            {
                return $"Setor não encontrado ({regSetor?.Id}).";
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

    private async Task<(bool, PrepostosResponseAll? )> IsCpfDuplicado(Models.Prepostos reg, IPrepostosService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return (false, null);
        var existingPrepostos = (await service.Filter(new Filters.FilterPrepostos { CPF = reg.CPF.ClearInputCpf() }, uri)).FirstOrDefault();
        return (existingPrepostos != null && existingPrepostos.Id > 0 && existingPrepostos.Id != reg.Id, existingPrepostos);
    }
}