namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessosObsReportService
{
    Task<IEnumerable<ProcessosObsReportResponseAll>> Filter(Filters.FilterProcessosObsReport filter, [FromRoute, Required] string uri = "");
    Task<ProcessosObsReportResponse?> AddAndUpdate(Models.ProcessosObsReport regProcessosObsReport, [FromRoute, Required] string uri = "");
    Task<ProcessosObsReportResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessosObsReportResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessosObsReportResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}