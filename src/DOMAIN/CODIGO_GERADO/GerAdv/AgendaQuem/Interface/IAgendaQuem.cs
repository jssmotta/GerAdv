namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaQuemService
{
    Task<IEnumerable<AgendaQuemResponse>> Filter(Filters.FilterAgendaQuem filter, [FromRoute, Required] string uri = "");
    Task<AgendaQuemResponse?> AddAndUpdate(Models.AgendaQuem regAgendaQuem, [FromRoute, Required] string uri = "");
    Task<AgendaQuemResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaQuemResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<AgendaQuemResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}