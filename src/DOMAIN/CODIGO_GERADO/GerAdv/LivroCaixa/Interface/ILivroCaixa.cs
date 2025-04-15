namespace MenphisSI.GerAdv.Interface;
public partial interface ILivroCaixaService
{
    Task<IEnumerable<LivroCaixaResponse>> Filter(Filters.FilterLivroCaixa filter, [FromRoute, Required] string uri = "");
    Task<LivroCaixaResponse?> AddAndUpdate(Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri = "");
    Task<LivroCaixaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<LivroCaixaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<LivroCaixaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}