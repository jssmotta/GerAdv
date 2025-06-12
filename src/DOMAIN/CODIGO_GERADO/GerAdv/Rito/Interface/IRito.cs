namespace MenphisSI.GerAdv.Interface;
public partial interface IRitoService
{
    Task<IEnumerable<RitoResponseAll>> Filter(Filters.FilterRito filter, [FromRoute, Required] string uri = "");
    Task<RitoResponse?> AddAndUpdate(Models.Rito regRito, [FromRoute, Required] string uri = "");
    Task<RitoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<RitoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<RitoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterRito? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}