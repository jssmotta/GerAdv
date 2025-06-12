namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaService
{
    Task<IEnumerable<AgendaResponseAll>> Filter(Filters.FilterAgenda filter, [FromRoute, Required] string uri = "");
    Task<AgendaResponse?> AddAndUpdate(Models.Agenda regAgenda, [FromRoute, Required] string uri = "");
    Task<AgendaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AgendaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}