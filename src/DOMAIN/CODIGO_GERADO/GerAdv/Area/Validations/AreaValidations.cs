#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Validations;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaValidation
{
    Task<string> ValidateReg(Models.Area reg, IAreaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
    Task<string> CanDelete(int id, IAreaService service, IAcaoService acaoService, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAreasJusticaService areasjusticaService, IDivisaoTribunalService divisaotribunalService, IFaseService faseService, IObjetosService objetosService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, IProcessosService processosService, ITipoRecursoService tiporecursoService, ITribunalService tribunalService, [FromRoute, Required] string uri, MsiSqlConnection oCnn);
}

public class AreaValidation : IAreaValidation
{
    public async Task<string> CanDelete(int id, IAreaService service, IAcaoService acaoService, IAgendaService agendaService, IAgendaFinanceiroService agendafinanceiroService, IAreasJusticaService areasjusticaService, IDivisaoTribunalService divisaotribunalService, IFaseService faseService, IObjetosService objetosService, IPoderJudiciarioAssociadoService poderjudiciarioassociadoService, IProcessosService processosService, ITipoRecursoService tiporecursoService, ITribunalService tribunalService, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (id <= 0)
            return "Id inválido";
        var reg = await service.GetById(id, uri, default);
        if (reg == null)
            return $"Registro com id {id} não encontrado.";
        var acaoExists0 = await acaoService.Filter(new Filters.FilterAcao { Area = id }, uri);
        if (acaoExists0 != null && acaoExists0.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Acao associados a ele.";
        var agendaExists1 = await agendaService.Filter(new Filters.FilterAgenda { Area = id }, uri);
        if (agendaExists1 != null && agendaExists1.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda associados a ele.";
        var agendafinanceiroExists2 = await agendafinanceiroService.Filter(new Filters.FilterAgendaFinanceiro { Area = id }, uri);
        if (agendafinanceiroExists2 != null && agendafinanceiroExists2.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Agenda Financeiro associados a ele.";
        var areasjusticaExists3 = await areasjusticaService.Filter(new Filters.FilterAreasJustica { Area = id }, uri);
        if (areasjusticaExists3 != null && areasjusticaExists3.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Areas Justica associados a ele.";
        var divisaotribunalExists4 = await divisaotribunalService.Filter(new Filters.FilterDivisaoTribunal { Area = id }, uri);
        if (divisaotribunalExists4 != null && divisaotribunalExists4.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Divisao Tribunal associados a ele.";
        var faseExists5 = await faseService.Filter(new Filters.FilterFase { Area = id }, uri);
        if (faseExists5 != null && faseExists5.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Fase associados a ele.";
        var objetosExists6 = await objetosService.Filter(new Filters.FilterObjetos { Area = id }, uri);
        if (objetosExists6 != null && objetosExists6.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Objetos associados a ele.";
        var poderjudiciarioassociadoExists7 = await poderjudiciarioassociadoService.Filter(new Filters.FilterPoderJudiciarioAssociado { Area = id }, uri);
        if (poderjudiciarioassociadoExists7 != null && poderjudiciarioassociadoExists7.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Poder Judiciario Associado associados a ele.";
        var processosExists8 = await processosService.Filter(new Filters.FilterProcessos { Area = id }, uri);
        if (processosExists8 != null && processosExists8.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Processos associados a ele.";
        var tiporecursoExists9 = await tiporecursoService.Filter(new Filters.FilterTipoRecurso { Area = id }, uri);
        if (tiporecursoExists9 != null && tiporecursoExists9.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Tipo Recurso associados a ele.";
        var tribunalExists10 = await tribunalService.Filter(new Filters.FilterTribunal { Area = id }, uri);
        if (tribunalExists10 != null && tribunalExists10.Any())
            return "Não é possível excluir o registro, pois existem registros da tabela Tribunal associados a ele.";
        return string.Empty;
    }

    public async Task<string> ValidateReg(Models.Area reg, IAreaService service, [FromRoute, Required] string uri, MsiSqlConnection oCnn)
    {
        if (reg == null)
            return "Objeto está nulo";
        if (string.IsNullOrWhiteSpace(reg.Descricao))
            return "Descricao é obrigatório";
        if (await IsDuplicado(reg, service, uri))
            return $"Area '{reg.Descricao}'  - Descricao";
        return string.Empty;
    }

    private async Task<bool> IsDuplicado(Models.Area reg, IAreaService service, string uri)
    {
        var existingArea = (await service.Filter(new Filters.FilterArea { Descricao = reg.Descricao }, uri)).FirstOrDefault(); // TRACK 10042025
        return existingArea != null && existingArea.Id > 0 && existingArea.Id != reg.Id;
    }
}