namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGruposAgendaService
{
    Task<IEnumerable<OperadorGruposAgendaResponse>> Filter(Filters.FilterOperadorGruposAgenda filter, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> AddAndUpdate(Models.OperadorGruposAgenda regOperadorGruposAgenda, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorGruposAgendaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorGruposAgenda? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}