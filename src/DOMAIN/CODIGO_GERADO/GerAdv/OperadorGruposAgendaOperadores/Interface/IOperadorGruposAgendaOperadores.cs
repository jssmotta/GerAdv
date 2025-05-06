namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGruposAgendaOperadoresService
{
    Task<IEnumerable<OperadorGruposAgendaOperadoresResponse>> Filter(Filters.FilterOperadorGruposAgendaOperadores filter, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaOperadoresResponse?> AddAndUpdate(Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaOperadoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorGruposAgendaOperadoresResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorGruposAgendaOperadoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}