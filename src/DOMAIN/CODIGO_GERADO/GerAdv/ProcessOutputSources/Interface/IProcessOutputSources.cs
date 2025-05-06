namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessOutputSourcesService
{
    Task<IEnumerable<ProcessOutputSourcesResponse>> Filter(Filters.FilterProcessOutputSources filter, [FromRoute, Required] string uri = "");
    Task<ProcessOutputSourcesResponse?> AddAndUpdate(Models.ProcessOutputSources regProcessOutputSources, [FromRoute, Required] string uri = "");
    Task<ProcessOutputSourcesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessOutputSourcesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessOutputSourcesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProcessOutputSourcesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutputSources? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}