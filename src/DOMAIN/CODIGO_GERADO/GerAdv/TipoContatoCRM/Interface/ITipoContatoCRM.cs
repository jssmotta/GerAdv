namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoContatoCRMService
{
    Task<IEnumerable<TipoContatoCRMResponseAll>> Filter(Filters.FilterTipoContatoCRM filter, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> AddAndUpdate(Models.TipoContatoCRM regTipoContatoCRM, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoContatoCRMResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> Validation(Models.TipoContatoCRM regTipoContatoCRM, [FromRoute, Required] string uri = "");
    Task<IEnumerable<TipoContatoCRMResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoContatoCRM? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}