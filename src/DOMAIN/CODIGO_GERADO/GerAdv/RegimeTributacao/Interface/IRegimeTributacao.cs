namespace MenphisSI.GerAdv.Interface;
public partial interface IRegimeTributacaoService
{
    Task<IEnumerable<RegimeTributacaoResponse>> Filter(Filters.FilterRegimeTributacao filter, [FromRoute, Required] string uri = "");
    Task<RegimeTributacaoResponse?> AddAndUpdate(Models.RegimeTributacao regRegimeTributacao, [FromRoute, Required] string uri = "");
    Task<RegimeTributacaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<RegimeTributacaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<RegimeTributacaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<RegimeTributacaoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterRegimeTributacao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}