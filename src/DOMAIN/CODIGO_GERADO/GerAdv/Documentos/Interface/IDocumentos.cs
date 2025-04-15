namespace MenphisSI.GerAdv.Interface;
public partial interface IDocumentosService
{
    Task<IEnumerable<DocumentosResponse>> Filter(Filters.FilterDocumentos filter, [FromRoute, Required] string uri = "");
    Task<DocumentosResponse?> AddAndUpdate(Models.Documentos regDocumentos, [FromRoute, Required] string uri = "");
    Task<DocumentosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<DocumentosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<DocumentosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}