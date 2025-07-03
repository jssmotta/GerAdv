namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoProDespositoService
{
    Task<IEnumerable<TipoProDespositoResponseAll>> Filter(Filters.FilterTipoProDesposito filter, [FromRoute, Required] string uri = "");
    Task<TipoProDespositoResponse?> AddAndUpdate(Models.TipoProDesposito regTipoProDesposito, [FromRoute, Required] string uri = "");
    Task<TipoProDespositoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoProDespositoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoProDespositoResponse?> Validation(Models.TipoProDesposito regTipoProDesposito, [FromRoute, Required] string uri = "");
    Task<IEnumerable<TipoProDespositoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoProDesposito? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}