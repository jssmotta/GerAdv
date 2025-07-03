namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGruposAgendaService
{
    Task<IEnumerable<OperadorGruposAgendaResponseAll>> Filter(Filters.FilterOperadorGruposAgenda filter, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> AddAndUpdate(Models.OperadorGruposAgenda regOperadorGruposAgenda, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorGruposAgendaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> Validation(Models.OperadorGruposAgenda regOperadorGruposAgenda, [FromRoute, Required] string uri = "");
    Task<IEnumerable<OperadorGruposAgendaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorGruposAgenda? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}