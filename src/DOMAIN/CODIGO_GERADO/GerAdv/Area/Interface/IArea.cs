namespace MenphisSI.GerAdv.Interface;
public partial interface IAreaService
{
    Task<IEnumerable<AreaResponse>> Filter(Filters.FilterArea filter, [FromRoute, Required] string uri = "");
    Task<AreaResponse?> AddAndUpdate(Models.Area regArea, [FromRoute, Required] string uri = "");
    Task<AreaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AreaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AreaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AreaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterArea? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}