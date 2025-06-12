namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusInstanciaService
{
    Task<IEnumerable<StatusInstanciaResponseAll>> Filter(Filters.FilterStatusInstancia filter, [FromRoute, Required] string uri = "");
    Task<StatusInstanciaResponse?> AddAndUpdate(Models.StatusInstancia regStatusInstancia, [FromRoute, Required] string uri = "");
    Task<StatusInstanciaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusInstanciaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<StatusInstanciaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusInstancia? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}