namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTPeriodicidadeStatusService
{
    Task<IEnumerable<GUTPeriodicidadeStatusResponse>> Filter(Filters.FilterGUTPeriodicidadeStatus filter, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeStatusResponse?> AddAndUpdate(Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeStatusResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTPeriodicidadeStatusResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeStatusResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}