namespace MenphisSI.GerAdv.Interface;
public partial interface IAgendaRepetirDiasService
{
    Task<IEnumerable<AgendaRepetirDiasResponseAll>> Filter(Filters.FilterAgendaRepetirDias filter, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirDiasResponse?> AddAndUpdate(Models.AgendaRepetirDias regAgendaRepetirDias, [FromRoute, Required] string uri = "");
    Task<AgendaRepetirDiasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AgendaRepetirDiasResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AgendaRepetirDiasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}