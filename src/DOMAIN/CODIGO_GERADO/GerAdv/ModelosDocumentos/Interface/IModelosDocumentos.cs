namespace MenphisSI.GerAdv.Interface;
public partial interface IModelosDocumentosService
{
    Task<IEnumerable<ModelosDocumentosResponseAll>> Filter(Filters.FilterModelosDocumentos filter, [FromRoute, Required] string uri = "");
    Task<ModelosDocumentosResponse?> AddAndUpdate(Models.ModelosDocumentos regModelosDocumentos, [FromRoute, Required] string uri = "");
    Task<ModelosDocumentosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ModelosDocumentosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ModelosDocumentosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterModelosDocumentos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}