namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaStatusService
{
    Task<IEnumerable<AgendaStatusResponse>> Filter(Filters.FilterAgendaStatus filter, [FromRoute, Required] string uri = "");
    Task<AgendaStatusResponse?> AddAndUpdate(Models.AgendaStatus regAgendaStatus, [FromRoute, Required] string uri = "");
    Task<AgendaStatusResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaStatusResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AgendaStatusResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}