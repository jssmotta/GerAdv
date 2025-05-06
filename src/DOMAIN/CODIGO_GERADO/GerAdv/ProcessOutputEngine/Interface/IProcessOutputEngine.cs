namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessOutputEngineService
{
    Task<IEnumerable<ProcessOutputEngineResponse>> Filter(Filters.FilterProcessOutputEngine filter, [FromRoute, Required] string uri = "");
    Task<ProcessOutputEngineResponse?> AddAndUpdate(Models.ProcessOutputEngine regProcessOutputEngine, [FromRoute, Required] string uri = "");
    Task<ProcessOutputEngineResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessOutputEngineResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessOutputEngineResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProcessOutputEngineResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutputEngine? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}