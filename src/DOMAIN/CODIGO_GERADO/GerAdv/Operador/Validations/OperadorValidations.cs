#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorValidation
{
    Task<string> ValidateReg(Models.Operador reg, IOperadorService service, IStatusBiuReader statusbiuReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IOperadorService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAlarmSMSService alarmsmsService, IAlertasService alertasService, IAlertasEnviadosService alertasenviadosService, IContatoCRMService contatocrmService, IContatoCRMOperadorService contatocrmoperadorService, IDiario2Service diario2Service, IGUTAtividadesService gutatividadesService, IOperadorEMailPopupService operadoremailpopupService, IOperadorGrupoService operadorgrupoService, IOperadorGruposAgendaService operadorgruposagendaService, IOperadorGruposAgendaOperadoresService operadorgruposagendaoperadoresService, IPontoVirtualService pontovirtualService, IPontoVirtualAcessosService pontovirtualacessosService, IProcessosParadosService processosparadosService, IProcessOutputRequestService processoutputrequestService, IReuniaoPessoasService reuniaopessoasService, ISMSAliceService smsaliceService, IStatusBiuService statusbiuService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class OperadorValidation : IOperadorValidation
{
    public async Task<string> CanDelete(int id, IOperadorService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAlarmSMSService alarmsmsService, IAlertasService alertasService, IAlertasEnviadosService alertasenviadosService, IContatoCRMService contatocrmService, IContatoCRMOperadorService contatocrmoperadorService, IDiario2Service diario2Service, IGUTAtividadesService gutatividadesService, IOperadorEMailPopupService operadoremailpopupService, IOperadorGrupoService operadorgrupoService, IOperadorGruposAgendaService operadorgruposagendaService, IOperadorGruposAgendaOperadoresService operadorgruposagendaoperadoresService, IPontoVirtualService pontovirtualService, IPontoVirtualAcessosService pontovirtualacessosService, IProcessosParadosService processosparadosService, IProcessOutputRequestService processoutputrequestService, IReuniaoPessoasService reuniaopessoasService, ISMSAliceService smsaliceService, IStatusBiuService statusbiuService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists = await agendaService.Filter(new Filters.FilterAgenda { Usuario = id }, uri);
        if (agendaExists != null && agendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Usuario = id }, uri);
        if (agendafinanceiroExists != null && agendafinanceiroExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var alarmsmsExists = await alarmsmsService.Filter(new Filters.FilterAlarmSMS { Operador = id }, uri);
        if (alarmsmsExists != null && alarmsmsExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alarm S M S associados a ele.";
        var alertasExists = await alertasService.Filter(new Filters.FilterAlertas { Operador = id }, uri);
        if (alertasExists != null && alertasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alertas associados a ele.";
        var alertasenviadosExists = await alertasenviadosService.Filter(new Filters.FilterAlertasEnviados { Operador = id }, uri);
        if (alertasenviadosExists != null && alertasenviadosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alertas Enviados associados a ele.";
        var contatocrmExists = await contatocrmService.Filter(new Filters.FilterContatoCRM { Operador = id }, uri);
        if (contatocrmExists != null && contatocrmExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M associados a ele.";
        var contatocrmoperadorExists = await contatocrmoperadorService.Filter(new Filters.FilterContatoCRMOperador { Operador = id }, uri);
        if (contatocrmoperadorExists != null && contatocrmoperadorExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M Operador associados a ele.";
        var diario2Exists = await diario2Service.Filter(new Filters.FilterDiario2 { Operador = id }, uri);
        if (diario2Exists != null && diario2Exists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Diario2 associados a ele.";
        var gutatividadesExists = await gutatividadesService.Filter(new Filters.FilterGUTAtividades { Operador = id }, uri);
        if (gutatividadesExists != null && gutatividadesExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela G U T Atividades associados a ele.";
        var operadoremailpopupExists = await operadoremailpopupService.Filter(new Filters.FilterOperadorEMailPopup { Operador = id }, uri);
        if (operadoremailpopupExists != null && operadoremailpopupExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador E Mail Popup associados a ele.";
        var operadorgrupoExists = await operadorgrupoService.Filter(new Filters.FilterOperadorGrupo { Operador = id }, uri);
        if (operadorgrupoExists != null && operadorgrupoExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupo associados a ele.";
        var operadorgruposagendaExists = await operadorgruposagendaService.Filter(new Filters.FilterOperadorGruposAgenda { Operador = id }, uri);
        if (operadorgruposagendaExists != null && operadorgruposagendaExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupos Agenda associados a ele.";
        var operadorgruposagendaoperadoresExists = await operadorgruposagendaoperadoresService.Filter(new Filters.FilterOperadorGruposAgendaOperadores { Operador = id }, uri);
        if (operadorgruposagendaoperadoresExists != null && operadorgruposagendaoperadoresExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupos Agenda Operadores associados a ele.";
        var pontovirtualExists = await pontovirtualService.Filter(new Filters.FilterPontoVirtual { Operador = id }, uri);
        if (pontovirtualExists != null && pontovirtualExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ponto Virtual associados a ele.";
        var pontovirtualacessosExists = await pontovirtualacessosService.Filter(new Filters.FilterPontoVirtualAcessos { Operador = id }, uri);
        if (pontovirtualacessosExists != null && pontovirtualacessosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ponto Virtual Acessos associados a ele.";
        var processosparadosExists = await processosparadosService.Filter(new Filters.FilterProcessosParados { Operador = id }, uri);
        if (processosparadosExists != null && processosparadosExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Parados associados a ele.";
        var processoutputrequestExists = await processoutputrequestService.Filter(new Filters.FilterProcessOutputRequest { Operador = id }, uri);
        if (processoutputrequestExists != null && processoutputrequestExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Process Output Request associados a ele.";
        var reuniaopessoasExists = await reuniaopessoasService.Filter(new Filters.FilterReuniaoPessoas { Operador = id }, uri);
        if (reuniaopessoasExists != null && reuniaopessoasExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Reuniao Pessoas associados a ele.";
        var smsaliceExists = await smsaliceService.Filter(new Filters.FilterSMSAlice { Operador = id }, uri);
        if (smsaliceExists != null && smsaliceExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela S M S Alice associados a ele.";
        var statusbiuExists = await statusbiuService.Filter(new Filters.FilterStatusBiu { Operador = id }, uri);
        if (statusbiuExists != null && statusbiuExists.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Status Biu associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Operador reg, IOperadorService service, IStatusBiuReader statusbiuReader, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Nome))
            return "Nome é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Operador '{reg.Nome}' já cadastrado.";
        // StatusBiu
        if (!reg.StatusId.IsEmptyIDNumber())
        {
            var regStatusBiu = statusbiuReader.Read(reg.StatusId, oCnn);
            if (regStatusBiu == null || regStatusBiu.Id != reg.StatusId)
            {
                return $"Status Biu não encontrado ({regStatusBiu?.Id}).";
            }
        }

        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Operador reg, IOperadorService service, string uri)
    {
        var existingOperador = (await service.Filter(new Filters.FilterOperador { Nome = reg.Nome }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingOperador != null && existingOperador.Id > 0 && existingOperador.Id != reg.Id;
    }
}