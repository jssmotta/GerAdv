namespace MenphisSI.GerAdv.Interface;
public partial interface ITiposAcaoService
{
    Task<IEnumerable<TiposAcaoResponseAll>> Filter(Filters.FilterTiposAcao filter, [FromRoute, Required] string uri = "");
    Task<TiposAcaoResponse?> AddAndUpdate(Models.TiposAcao regTiposAcao, [FromRoute, Required] string uri = "");
    Task<TiposAcaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TiposAcaoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TiposAcaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTiposAcao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}