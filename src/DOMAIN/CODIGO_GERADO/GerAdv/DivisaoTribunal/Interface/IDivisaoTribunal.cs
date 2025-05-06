namespace MenphisSI.GerAdv.Interface;
public partial interface IDivisaoTribunalService
{
    Task<IEnumerable<DivisaoTribunalResponse>> Filter(Filters.FilterDivisaoTribunal filter, [FromRoute, Required] string uri = "");
    Task<DivisaoTribunalResponse?> AddAndUpdate(Models.DivisaoTribunal regDivisaoTribunal, [FromRoute, Required] string uri = "");
    Task<DivisaoTribunalResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<DivisaoTribunalResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<DivisaoTribunalResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}