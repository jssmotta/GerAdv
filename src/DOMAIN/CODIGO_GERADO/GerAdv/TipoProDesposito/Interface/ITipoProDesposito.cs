namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoProDespositoService
{
    Task<IEnumerable<TipoProDespositoResponse>> Filter(Filters.FilterTipoProDesposito filter, [FromRoute, Required] string uri = "");
    Task<TipoProDespositoResponse?> AddAndUpdate(Models.TipoProDesposito regTipoProDesposito, [FromRoute, Required] string uri = "");
    Task<TipoProDespositoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoProDespositoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoProDespositoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoProDespositoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoProDesposito? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}