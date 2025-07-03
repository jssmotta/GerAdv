namespace MenphisSI.GerAdv.Interface;
public partial interface IDocumentosService
{
    Task<IEnumerable<DocumentosResponseAll>> Filter(Filters.FilterDocumentos filter, [FromRoute, Required] string uri = "");
    Task<DocumentosResponse?> AddAndUpdate(Models.Documentos regDocumentos, [FromRoute, Required] string uri = "");
    Task<DocumentosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<DocumentosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<DocumentosResponse?> Validation(Models.Documentos regDocumentos, [FromRoute, Required] string uri = "");
    Task<IEnumerable<DocumentosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}