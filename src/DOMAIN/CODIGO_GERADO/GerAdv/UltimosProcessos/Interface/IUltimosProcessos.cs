namespace MenphisSI.GerAdv.Interface;
public partial interface IUltimosProcessosService
{
    Task<IEnumerable<UltimosProcessosResponse>> Filter(Filters.FilterUltimosProcessos filter, [FromRoute, Required] string uri = "");
    Task<UltimosProcessosResponse?> AddAndUpdate(Models.UltimosProcessos regUltimosProcessos, [FromRoute, Required] string uri = "");
    Task<UltimosProcessosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<UltimosProcessosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<UltimosProcessosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}