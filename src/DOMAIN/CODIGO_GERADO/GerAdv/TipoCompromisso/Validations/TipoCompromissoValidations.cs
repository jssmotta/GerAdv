#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoValidation
{
    Task<string> ValidateReg(Models.TipoCompromisso reg, ITipoCompromissoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, ITipoCompromissoService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, INECompromissosService necompromissosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class TipoCompromissoValidation : ITipoCompromissoValidation
{
    public async Task<string> CanDelete(int id, ITipoCompromissoService service, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, INECompromissosService necompromissosService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var agendaExists0 = await agendaService.Filter(new Filters.FilterAgenda { TipoCompromisso = id }, uri);
        if (agendaExists0 != null && agendaExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists1 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { TipoCompromisso = id }, uri);
        if (agendafinanceiroExists1 != null && agendafinanceiroExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var necompromissosExists2 = await necompromissosService.Filter(new Filters.FilterNECompromissos { TipoCompromisso = id }, uri);
        if (necompromissosExists2 != null && necompromissosExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela N E Compromissos associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.TipoCompromisso reg, ITipoCompromissoService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Tipo Compromisso '{reg.Descricao}'  - Descricao";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.TipoCompromisso reg, ITipoCompromissoService service, string uri)
    {
        var existingTipoCompromisso = (await service.Filter(new Filters.FilterTipoCompromisso { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingTipoCompromisso != null && existingTipoCompromisso.Id > 0 && existingTipoCompromisso.Id != reg.Id;
    }
}