namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessosService
{
    Task<IEnumerable<ProcessosResponse>> Filter(Filters.FilterProcessos filter, [FromRoute, Required] string uri = "");
    Task<ProcessosResponse?> AddAndUpdate(Models.Processos regProcessos, [FromRoute, Required] string uri = "");
    Task<ProcessosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ProcessosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProcessosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}