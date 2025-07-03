namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoCompromissoService
{
    Task<IEnumerable<TipoCompromissoResponseAll>> Filter(Filters.FilterTipoCompromisso filter, [FromRoute, Required] string uri = "");
    Task<TipoCompromissoResponse?> AddAndUpdate(Models.TipoCompromisso regTipoCompromisso, [FromRoute, Required] string uri = "");
    Task<TipoCompromissoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoCompromissoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoCompromissoResponse?> Validation(Models.TipoCompromisso regTipoCompromisso, [FromRoute, Required] string uri = "");
    Task<IEnumerable<TipoCompromissoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoCompromisso? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}