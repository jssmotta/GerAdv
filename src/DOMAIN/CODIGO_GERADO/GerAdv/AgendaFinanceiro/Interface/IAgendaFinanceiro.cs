namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaFinanceiroService
{
    Task<IEnumerable<AgendaFinanceiroResponseAll>> Filter(Filters.FilterAgendaFinanceiro filter, [FromRoute, Required] string uri = "");
    Task<AgendaFinanceiroResponse?> AddAndUpdate(Models.AgendaFinanceiro regAgendaFinanceiro, [FromRoute, Required] string uri = "");
    Task<AgendaFinanceiroResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaFinanceiroResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AgendaFinanceiroResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}