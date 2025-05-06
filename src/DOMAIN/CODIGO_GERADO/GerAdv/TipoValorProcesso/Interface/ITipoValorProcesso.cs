namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoValorProcessoService
{
    Task<IEnumerable<TipoValorProcessoResponse>> Filter(Filters.FilterTipoValorProcesso filter, [FromRoute, Required] string uri = "");
    Task<TipoValorProcessoResponse?> AddAndUpdate(Models.TipoValorProcesso regTipoValorProcesso, [FromRoute, Required] string uri = "");
    Task<TipoValorProcessoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoValorProcessoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoValorProcessoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoValorProcessoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoValorProcesso? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}