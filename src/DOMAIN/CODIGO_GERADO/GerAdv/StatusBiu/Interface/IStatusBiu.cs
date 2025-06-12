namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusBiuService
{
    Task<IEnumerable<StatusBiuResponseAll>> Filter(Filters.FilterStatusBiu filter, [FromRoute, Required] string uri = "");
    Task<StatusBiuResponse?> AddAndUpdate(Models.StatusBiu regStatusBiu, [FromRoute, Required] string uri = "");
    Task<StatusBiuResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusBiuResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<StatusBiuResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusBiu? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}