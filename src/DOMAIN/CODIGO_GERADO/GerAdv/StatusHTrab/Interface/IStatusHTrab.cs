namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusHTrabService
{
    Task<IEnumerable<StatusHTrabResponse>> Filter(Filters.FilterStatusHTrab filter, [FromRoute, Required] string uri = "");
    Task<StatusHTrabResponse?> AddAndUpdate(Models.StatusHTrab regStatusHTrab, [FromRoute, Required] string uri = "");
    Task<StatusHTrabResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusHTrabResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<StatusHTrabResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<StatusHTrabResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusHTrab? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}