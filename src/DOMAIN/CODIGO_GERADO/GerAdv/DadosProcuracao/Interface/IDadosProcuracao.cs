namespace MenphisSI.GerAdv.Interface;
public partial interface IDadosProcuracaoService
{
    Task<IEnumerable<DadosProcuracaoResponse>> Filter(Filters.FilterDadosProcuracao filter, [FromRoute, Required] string uri = "");
    Task<DadosProcuracaoResponse?> AddAndUpdate(Models.DadosProcuracao regDadosProcuracao, [FromRoute, Required] string uri = "");
    Task<DadosProcuracaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<DadosProcuracaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<DadosProcuracaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}