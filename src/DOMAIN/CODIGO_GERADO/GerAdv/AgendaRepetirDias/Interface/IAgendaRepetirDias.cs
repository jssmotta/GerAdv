namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaRepetirDiasService
{
    Task<IEnumerable<AgendaRepetirDiasResponse>> Filter(Filters.FilterAgendaRepetirDias filter, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirDiasResponse?> AddAndUpdate(Models.AgendaRepetirDias regAgendaRepetirDias, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirDiasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaRepetirDiasResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirDiasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}