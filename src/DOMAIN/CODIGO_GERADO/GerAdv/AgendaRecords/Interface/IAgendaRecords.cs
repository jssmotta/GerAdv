namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaRecordsService
{
    Task<IEnumerable<AgendaRecordsResponse>> Filter(Filters.FilterAgendaRecords filter, [FromRoute, Required] string uri = "");
    Task<AgendaRecordsResponse?> AddAndUpdate(Models.AgendaRecords regAgendaRecords, [FromRoute, Required] string uri = "");
    Task<AgendaRecordsResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaRecordsResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<AgendaRecordsResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}