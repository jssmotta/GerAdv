namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGruposService
{
    Task<IEnumerable<OperadorGruposResponse>> Filter(Filters.FilterOperadorGrupos filter, [FromRoute, Required] string uri = "");
    Task<OperadorGruposResponse?> AddAndUpdate(Models.OperadorGrupos regOperadorGrupos, [FromRoute, Required] string uri = "");
    Task<OperadorGruposResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorGruposResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorGruposResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OperadorGruposResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorGrupos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}