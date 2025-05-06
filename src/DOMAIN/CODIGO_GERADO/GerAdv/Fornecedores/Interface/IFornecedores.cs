namespace MenphisSI.GerAdv.Interface;
public partial interface IFornecedoresService
{
    Task<IEnumerable<FornecedoresResponse>> Filter(Filters.FilterFornecedores filter, [FromRoute, Required] string uri = "");
    Task<FornecedoresResponse?> AddAndUpdate(Models.Fornecedores regFornecedores, [FromRoute, Required] string uri = "");
    Task<FornecedoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<FornecedoresResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<FornecedoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<FornecedoresResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFornecedores? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}