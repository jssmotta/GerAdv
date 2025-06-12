namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGruposAgendaOperadoresService
{
    Task<IEnumerable<OperadorGruposAgendaOperadoresResponseAll>> Filter(Filters.FilterOperadorGruposAgendaOperadores filter, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaOperadoresResponse?> AddAndUpdate(Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, [FromRoute, Required] string uri = "");
    Task<OperadorGruposAgendaOperadoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorGruposAgendaOperadoresResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorGruposAgendaOperadoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}