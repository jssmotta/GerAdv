namespace MenphisSI.GerAdv.Interface;
public partial interface ITerceirosService
{
    Task<IEnumerable<TerceirosResponse>> Filter(Filters.FilterTerceiros filter, [FromRoute, Required] string uri = "");
    Task<TerceirosResponse?> AddAndUpdate(Models.Terceiros regTerceiros, [FromRoute, Required] string uri = "");
    Task<TerceirosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TerceirosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TerceirosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TerceirosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTerceiros? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}