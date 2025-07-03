namespace MenphisSI.GerAdv.Interface;
public partial interface ILivroCaixaService
{
    Task<IEnumerable<LivroCaixaResponseAll>> Filter(Filters.FilterLivroCaixa filter, [FromRoute, Required] string uri = "");
    Task<LivroCaixaResponse?> AddAndUpdate(Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri = "");
    Task<LivroCaixaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<LivroCaixaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<LivroCaixaResponse?> Validation(Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri = "");
    Task<IEnumerable<LivroCaixaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}