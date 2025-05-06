namespace MenphisSI.GerAdv.Interface;
public partial interface IDocsRecebidosItensService
{
    Task<IEnumerable<DocsRecebidosItensResponse>> Filter(Filters.FilterDocsRecebidosItens filter, [FromRoute, Required] string uri = "");
    Task<DocsRecebidosItensResponse?> AddAndUpdate(Models.DocsRecebidosItens regDocsRecebidosItens, [FromRoute, Required] string uri = "");
    Task<DocsRecebidosItensResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<DocsRecebidosItensResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<DocsRecebidosItensResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<DocsRecebidosItensResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterDocsRecebidosItens? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}