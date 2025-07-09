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
        var agendaExists0 = await agendaService.Filter(new Filters.FilterAgenda { Usuario = id }, uri);
        if (agendaExists0 != null && agendaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists1 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Usuario = id }, uri);
        if (agendafinanceiroExists1 != null && agendafinanceiroExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var alarmsmsExists2 = await alarmsmsService.Filter(new Filters.FilterAlarmSMS { Operador = id }, uri);
        if (alarmsmsExists2 != null && alarmsmsExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alarm S M S associados a ele.";
        var alertasExists3 = await alertasService.Filter(new Filters.FilterAlertas { Operador = id }, uri);
        if (alertasExists3 != null && alertasExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alertas associados a ele.";
        var alertasenviadosExists4 = await alertasenviadosService.Filter(new Filters.FilterAlertasEnviados { Operador = id }, uri);
        if (alertasenviadosExists4 != null && alertasenviadosExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Alertas Enviados associados a ele.";
        var contatocrmExists5 = await contatocrmService.Filter(new Filters.FilterContatoCRM { Operador = id }, uri);
        if (contatocrmExists5 != null && contatocrmExists5.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M associados a ele.";
        var contatocrmoperadorExists6 = await contatocrmoperadorService.Filter(new Filters.FilterContatoCRMOperador { Operador = id }, uri);
        if (contatocrmoperadorExists6 != null && contatocrmoperadorExists6.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Contato C R M Operador associados a ele.";
        var diario2Exists7 = await diario2Service.Filter(new Filters.FilterDiario2 { Operador = id }, uri);
        if (diario2Exists7 != null && diario2Exists7.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Diario2 associados a ele.";
        var gutatividadesExists8 = await gutatividadesService.Filter(new Filters.FilterGUTAtividades { Operador = id }, uri);
        if (gutatividadesExists8 != null && gutatividadesExists8.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela G U T Atividades associados a ele.";
        var operadoremailpopupExists9 = await operadoremailpopupService.Filter(new Filters.FilterOperadorEMailPopup { Operador = id }, uri);
        if (operadoremailpopupExists9 != null && operadoremailpopupExists9.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador E Mail Popup associados a ele.";
        var operadorgrupoExists10 = await operadorgrupoService.Filter(new Filters.FilterOperadorGrupo { Operador = id }, uri);
        if (operadorgrupoExists10 != null && operadorgrupoExists10.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupo associados a ele.";
        var operadorgruposagendaExists11 = await operadorgruposagendaService.Filter(new Filters.FilterOperadorGruposAgenda { Operador = id }, uri);
        if (operadorgruposagendaExists11 != null && operadorgruposagendaExists11.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupos Agenda associados a ele.";
        var operadorgruposagendaoperadoresExists12 = await operadorgruposagendaoperadoresService.Filter(new Filters.FilterOperadorGruposAgendaOperadores { Operador = id }, uri);
        if (operadorgruposagendaoperadoresExists12 != null && operadorgruposagendaoperadoresExists12.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Operador Grupos Agenda Operadores associados a ele.";
        var pontovirtualExists13 = await pontovirtualService.Filter(new Filters.FilterPontoVirtual { Operador = id }, uri);
        if (pontovirtualExists13 != null && pontovirtualExists13.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ponto Virtual associados a ele.";
        var pontovirtualacessosExists14 = await pontovirtualacessosService.Filter(new Filters.FilterPontoVirtualAcessos { Operador = id }, uri);
        if (pontovirtualacessosExists14 != null && pontovirtualacessosExists14.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Ponto Virtual Acessos associados a ele.";
        var processosparadosExists15 = await processosparadosService.Filter(new Filters.FilterProcessosParados { Operador = id }, uri);
        if (processosparadosExists15 != null && processosparadosExists15.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos Parados associados a ele.";
        var processoutputrequestExists16 = await processoutputrequestService.Filter(new Filters.FilterProcessOutputRequest { Operador = id }, uri);
        if (processoutputrequestExists16 != null && processoutputrequestExists16.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Process Output Request associados a ele.";
        var reuniaopessoasExists17 = await reuniaopessoasService.Filter(new Filters.FilterReuniaoPessoas { Operador = id }, uri);
        if (reuniaopessoasExists17 != null && reuniaopessoasExists17.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Reuniao Pessoas associados a ele.";
        var smsaliceExists18 = await smsaliceService.Filter(new Filters.FilterSMSAlice { Operador = id }, uri);
        if (smsaliceExists18 != null && smsaliceExists18.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela S M S Alice associados a ele.";
        var statusbiuExists19 = await statusbiuService.Filter(new Filters.FilterStatusBiu { Operador = id }, uri);
        if (statusbiuExists19 != null && statusbiuExists19.Any())
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
            return $"Operador '{reg.Nome}'  - Nome";
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