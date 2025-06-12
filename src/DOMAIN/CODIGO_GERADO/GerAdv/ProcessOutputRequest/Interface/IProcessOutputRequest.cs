namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessOutputRequestService
{
    Task<IEnumerable<ProcessOutputRequestResponseAll>> Filter(Filters.FilterProcessOutputRequest filter, [FromRoute, Required] string uri = "");
    Task<ProcessOutputRequestResponse?> AddAndUpdate(Models.ProcessOutputRequest regProcessOutputRequest, [FromRoute, Required] string uri = "");
    Task<ProcessOutputRequestResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessOutputRequestResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessOutputRequestResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}