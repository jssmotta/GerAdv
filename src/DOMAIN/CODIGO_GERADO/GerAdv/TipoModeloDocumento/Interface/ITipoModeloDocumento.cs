namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoModeloDocumentoService
{
    Task<IEnumerable<TipoModeloDocumentoResponseAll>> Filter(Filters.FilterTipoModeloDocumento filter, [FromRoute, Required] string uri = "");
    Task<TipoModeloDocumentoResponse?> AddAndUpdate(Models.TipoModeloDocumento regTipoModeloDocumento, [FromRoute, Required] string uri = "");
    Task<TipoModeloDocumentoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoModeloDocumentoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoModeloDocumentoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoModeloDocumento? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}