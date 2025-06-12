namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusTarefasService
{
    Task<IEnumerable<StatusTarefasResponseAll>> Filter(Filters.FilterStatusTarefas filter, [FromRoute, Required] string uri = "");
    Task<StatusTarefasResponse?> AddAndUpdate(Models.StatusTarefas regStatusTarefas, [FromRoute, Required] string uri = "");
    Task<StatusTarefasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusTarefasResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<StatusTarefasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusTarefas? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}