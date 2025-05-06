namespace MenphisSI.GerAdv.Interface;
public partial interface ICargosService
{
    Task<IEnumerable<CargosResponse>> Filter(Filters.FilterCargos filter, [FromRoute, Required] string uri = "");
    Task<CargosResponse?> AddAndUpdate(Models.Cargos regCargos, [FromRoute, Required] string uri = "");
    Task<CargosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<CargosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<CargosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<CargosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterCargos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}