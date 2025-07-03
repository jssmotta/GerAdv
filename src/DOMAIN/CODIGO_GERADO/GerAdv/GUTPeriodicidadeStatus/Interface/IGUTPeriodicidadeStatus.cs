namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTPeriodicidadeStatusService
{
    Task<IEnumerable<GUTPeriodicidadeStatusResponseAll>> Filter(Filters.FilterGUTPeriodicidadeStatus filter, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeStatusResponse?> AddAndUpdate(Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeStatusResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTPeriodicidadeStatusResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeStatusResponse?> Validation(Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri = "");
    Task<IEnumerable<GUTPeriodicidadeStatusResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}