namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaRepetirService
{
    Task<IEnumerable<AgendaRepetirResponse>> Filter(Filters.FilterAgendaRepetir filter, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirResponse?> AddAndUpdate(Models.AgendaRepetir regAgendaRepetir, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaRepetirResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AgendaRepetirResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}