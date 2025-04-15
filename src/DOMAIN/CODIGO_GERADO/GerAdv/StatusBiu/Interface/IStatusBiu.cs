namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusBiuService
{
    Task<IEnumerable<StatusBiuResponse>> Filter(Filters.FilterStatusBiu filter, [FromRoute, Required] string uri = "");
    Task<StatusBiuResponse?> AddAndUpdate(Models.StatusBiu regStatusBiu, [FromRoute, Required] string uri = "");
    Task<StatusBiuResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusBiuResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<StatusBiuResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<StatusBiuResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusBiu? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}