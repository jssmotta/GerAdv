namespace MenphisSI.GerAdv.Interface;
public partial interface IAgenda2AgendaService
{
    Task<IEnumerable<Agenda2AgendaResponse>> Filter(Filters.FilterAgenda2Agenda filter, [FromRoute, Required] string uri = "");
    Task<Agenda2AgendaResponse?> AddAndUpdate(Models.Agenda2Agenda regAgenda2Agenda, [FromRoute, Required] string uri = "");
    Task<Agenda2AgendaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<Agenda2AgendaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<Agenda2AgendaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}