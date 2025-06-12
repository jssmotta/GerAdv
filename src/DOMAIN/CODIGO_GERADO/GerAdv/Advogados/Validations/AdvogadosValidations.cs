#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAdvogadosValidation
{
    Task<string> ValidateReg(Models.Advogados reg, IAdvogadosService service, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAdvogadosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IAgendaRepetirService agendarepetirService, IContratosService contratosService, IHorasTrabService horastrabService, IParceriaProcService parceriaprocService, IProcessosService processosService, IProProcuradoresService proprocuradoresService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AdvogadosValidation : IAdvogadosValidation
{
    public async Task<string> CanDelete(int id, IAdvogadosService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAgendaQuemService agendaquemService, IAgendaRepetirService agendarepetirService, IContratosService contratosService, IHorasTrabService horastrabService, IParceriaProcService parceriaprocService, IProcessosService processosService, IProProcuradoresService proprocuradoresService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists = await agendaService.Filter(new Filters.FilterAgenda { Advogado = id }, uri);
        if (agendaExists != null && agendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Advogado = id }, uri);
        if (agendafinanceiroExists != null && agendafinanceiroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var agendaquemExists = await agendaquemService.Filter(new Filters.FilterAgendaQuem { Advogado = id }, uri);
        if (agendaquemExists != null && agendaquemExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Quem associados a ele.";
        var agendarepetirExists = await agendarepetirService.Filter(new Filters.FilterAgendaRepetir { Advogado = id }, uri);
        if (agendarepetirExists != null && agendarepetirExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Repetir associados a ele.";
        var contratosExists = await contratosService.Filter(new Filters.FilterContratos { Advogado = id }, uri);
        if (contratosExists != null && contratosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contratos associados a ele.";
        var horastrabExists = await horastrabService.Filter(new Filters.FilterHorasTrab { Advogado = id }, uri);
        if (horastrabExists != null && horastrabExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Horas Trab associados a ele.";
        var parceriaprocExists = await parceriaprocService.Filter(new Filters.FilterParceriaProc { Advogado = id }, uri);
        if (parceriaprocExists != null && parceriaprocExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Parceria Proc associados a ele.";
        var processosExists = await processosService.Filter(new Filters.FilterProcessos { AdvOpo = id }, uri);
        if (processosExists != null && processosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var processosExists = await processosService.Filter(new Filters.FilterProcessos { Advogado = id }, uri);
        if (processosExists != null && processosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var proprocuradoresExists = await proprocuradoresService.Filter(new Filters.FilterProProcuradores { Advogado = id }, uri);
        if (proprocuradoresExists != null && proprocuradoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Pro Procuradores associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Advogados reg, IAdvogadosService service, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, ICidadeReader cidadeReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Advogados '{reg.Nome}' já cadastrado.";
        if (!string.IsNullOrWhiteSpace(reg.CPF) && await IsCpfDuplicado(reg, service, uri))
            return $"'Advogados' com cpf '{reg.CPF.MaskCpf()}' já cadastrado.";
        // Cargos
        if (!reg.Cargo.IsEmptyIDNumber())
        {
            var regCargos = cargosReader.Read(reg.Cargo, oCnn);
            if (regCargos == null || regCargos.Id != reg.Cargo)
            {
                return $"Cargos não encontrado ({regCargos?.Id}).";
            }
        }

        // Escritorios
        if (!reg.Escritorio.IsEmptyIDNumber())
        {
            var regEscritorios = escritoriosReader.Read(reg.Escritorio, oCnn);
            if (regEscritorios == null || regEscritorios.Id != reg.Escritorio)
            {
                return $"Escritorios não encontrado ({regEscritorios?.Id}).";
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

    private async Task<bool> IsDuplicado(Models.Advogados reg, IAdvogadosService service, string uri)
    {
        var existingAdvogados = (await service.Filter(new Filters.FilterAdvogados { Escritorio = reg.Escritorio, Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingAdvogados != null && existingAdvogados.Id > 0 && existingAdvogados.Id != reg.Id;
    }

    private async Task<bool> IsCpfDuplicado(Models.Advogados reg, IAdvogadosService service, string uri)
    {
        if (reg.CPF.Length == 0)
            return false;
        var existingAdvogados = (await service.Filter(new Filters.FilterAdvogados { CPF = reg.CPF }, uri)).FirstOrDefault();
        return existingAdvogados != null && existingAdvogados.Id > 0 && existingAdvogados.Id != reg.Id;
    }
}