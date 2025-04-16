namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoContatoCRMService
{
    Task<IEnumerable<TipoContatoCRMResponse>> Filter(Filters.FilterTipoContatoCRM filter, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> AddAndUpdate(Models.TipoContatoCRM regTipoContatoCRM, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoContatoCRMResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoContatoCRMResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoContatoCRM? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}