namespace MenphisSI.GerAdv.Interface;
public partial interface IEventoPrazoAgendaService
{
    Task<IEnumerable<EventoPrazoAgendaResponse>> Filter(Filters.FilterEventoPrazoAgenda filter, [FromRoute, Required] string uri = "");
    Task<EventoPrazoAgendaResponse?> AddAndUpdate(Models.EventoPrazoAgenda regEventoPrazoAgenda, [FromRoute, Required] string uri = "");
    Task<EventoPrazoAgendaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EventoPrazoAgendaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EventoPrazoAgendaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<EventoPrazoAgendaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEventoPrazoAgenda? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}