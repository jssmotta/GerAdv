namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessosService
{
    Task<IEnumerable<ProcessosResponseAll>> Filter(Filters.FilterProcessos filter, [FromRoute, Required] string uri = "");
    Task<ProcessosResponse?> AddAndUpdate(Models.Processos regProcessos, [FromRoute, Required] string uri = "");
    Task<ProcessosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}