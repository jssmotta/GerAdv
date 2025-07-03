namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoStatusBiuService
{
    Task<IEnumerable<TipoStatusBiuResponseAll>> Filter(Filters.FilterTipoStatusBiu filter, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> AddAndUpdate(Models.TipoStatusBiu regTipoStatusBiu, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoStatusBiuResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> Validation(Models.TipoStatusBiu regTipoStatusBiu, [FromRoute, Required] string uri = "");
    Task<IEnumerable<TipoStatusBiuResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoStatusBiu? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}