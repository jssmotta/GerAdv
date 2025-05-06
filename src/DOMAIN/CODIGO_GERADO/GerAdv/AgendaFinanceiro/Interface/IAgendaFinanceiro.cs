namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaFinanceiroService
{
    Task<IEnumerable<AgendaFinanceiroResponse>> Filter(Filters.FilterAgendaFinanceiro filter, [FromRoute, Required] string uri = "");
    Task<AgendaFinanceiroResponse?> AddAndUpdate(Models.AgendaFinanceiro regAgendaFinanceiro, [FromRoute, Required] string uri = "");
    Task<AgendaFinanceiroResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaFinanceiroResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AgendaFinanceiroResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}