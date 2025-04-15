namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessosObsReportService
{
    Task<IEnumerable<ProcessosObsReportResponse>> Filter(Filters.FilterProcessosObsReport filter, [FromRoute, Required] string uri = "");
    Task<ProcessosObsReportResponse?> AddAndUpdate(Models.ProcessosObsReport regProcessosObsReport, [FromRoute, Required] string uri = "");
    Task<ProcessosObsReportResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessosObsReportResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ProcessosObsReportResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}