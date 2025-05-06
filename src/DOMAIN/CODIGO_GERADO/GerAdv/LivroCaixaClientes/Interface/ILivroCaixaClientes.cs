namespace MenphisSI.GerAdv.Interface;
public partial interface ILivroCaixaClientesService
{
    Task<IEnumerable<LivroCaixaClientesResponse>> Filter(Filters.FilterLivroCaixaClientes filter, [FromRoute, Required] string uri = "");
    Task<LivroCaixaClientesResponse?> AddAndUpdate(Models.LivroCaixaClientes regLivroCaixaClientes, [FromRoute, Required] string uri = "");
    Task<LivroCaixaClientesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<LivroCaixaClientesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<LivroCaixaClientesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}