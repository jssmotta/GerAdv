namespace MenphisSI.GerAdv.Interface;
public partial interface ITiposAcaoService
{
    Task<IEnumerable<TiposAcaoResponse>> Filter(Filters.FilterTiposAcao filter, [FromRoute, Required] string uri = "");
    Task<TiposAcaoResponse?> AddAndUpdate(Models.TiposAcao regTiposAcao, [FromRoute, Required] string uri = "");
    Task<TiposAcaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TiposAcaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TiposAcaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TiposAcaoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTiposAcao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}