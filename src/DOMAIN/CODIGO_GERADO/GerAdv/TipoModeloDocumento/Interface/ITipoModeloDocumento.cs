namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoModeloDocumentoService
{
    Task<IEnumerable<TipoModeloDocumentoResponse>> Filter(Filters.FilterTipoModeloDocumento filter, [FromRoute, Required] string uri = "");
    Task<TipoModeloDocumentoResponse?> AddAndUpdate(Models.TipoModeloDocumento regTipoModeloDocumento, [FromRoute, Required] string uri = "");
    Task<TipoModeloDocumentoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoModeloDocumentoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoModeloDocumentoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoModeloDocumentoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoModeloDocumento? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}