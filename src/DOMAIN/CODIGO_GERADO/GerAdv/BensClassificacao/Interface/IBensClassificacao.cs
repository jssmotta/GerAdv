namespace MenphisSI.GerAdv.Interface;
public partial interface IBensClassificacaoService
{
    Task<IEnumerable<BensClassificacaoResponse>> Filter(Filters.FilterBensClassificacao filter, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> AddAndUpdate(Models.BensClassificacao regBensClassificacao, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<BensClassificacaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<BensClassificacaoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterBensClassificacao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}