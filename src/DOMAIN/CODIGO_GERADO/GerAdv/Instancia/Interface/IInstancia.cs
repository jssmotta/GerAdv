namespace MenphisSI.GerAdv.Interface;
public partial interface IInstanciaService
{
    Task<IEnumerable<InstanciaResponse>> Filter(Filters.FilterInstancia filter, [FromRoute, Required] string uri = "");
    Task<InstanciaResponse?> AddAndUpdate(Models.Instancia regInstancia, [FromRoute, Required] string uri = "");
    Task<InstanciaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<InstanciaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<InstanciaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<InstanciaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterInstancia? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}