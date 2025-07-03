namespace MenphisSI.GerAdv.Interface;
public partial interface IBensClassificacaoService
{
    Task<IEnumerable<BensClassificacaoResponseAll>> Filter(Filters.FilterBensClassificacao filter, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> AddAndUpdate(Models.BensClassificacao regBensClassificacao, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<BensClassificacaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> Validation(Models.BensClassificacao regBensClassificacao, [FromRoute, Required] string uri = "");
    Task<IEnumerable<BensClassificacaoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterBensClassificacao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}