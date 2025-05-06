namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTMatrizService
{
    Task<IEnumerable<GUTMatrizResponse>> Filter(Filters.FilterGUTMatriz filter, [FromRoute, Required] string uri = "");
    Task<GUTMatrizResponse?> AddAndUpdate(Models.GUTMatriz regGUTMatriz, [FromRoute, Required] string uri = "");
    Task<GUTMatrizResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTMatrizResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTMatrizResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GUTMatrizResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTMatriz? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}