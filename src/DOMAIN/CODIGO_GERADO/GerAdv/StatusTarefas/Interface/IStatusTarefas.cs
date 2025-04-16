namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusTarefasService
{
    Task<IEnumerable<StatusTarefasResponse>> Filter(Filters.FilterStatusTarefas filter, [FromRoute, Required] string uri = "");
    Task<StatusTarefasResponse?> AddAndUpdate(Models.StatusTarefas regStatusTarefas, [FromRoute, Required] string uri = "");
    Task<StatusTarefasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusTarefasResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<StatusTarefasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<StatusTarefasResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusTarefas? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}