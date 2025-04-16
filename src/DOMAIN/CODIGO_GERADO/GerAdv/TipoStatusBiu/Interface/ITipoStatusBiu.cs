namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoStatusBiuService
{
    Task<IEnumerable<TipoStatusBiuResponse>> Filter(Filters.FilterTipoStatusBiu filter, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> AddAndUpdate(Models.TipoStatusBiu regTipoStatusBiu, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoStatusBiuResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoStatusBiuResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoStatusBiu? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}