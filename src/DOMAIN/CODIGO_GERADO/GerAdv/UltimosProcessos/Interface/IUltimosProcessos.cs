namespace MenphisSI.GerAdv.Interface;
public partial interface IUltimosProcessosService
{
    Task<IEnumerable<UltimosProcessosResponse>> Filter(Filters.FilterUltimosProcessos filter, [FromRoute, Required] string uri = "");
    Task<UltimosProcessosResponse?> AddAndUpdate(Models.UltimosProcessos regUltimosProcessos, [FromRoute, Required] string uri = "");
    Task<UltimosProcessosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<UltimosProcessosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<UltimosProcessosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}