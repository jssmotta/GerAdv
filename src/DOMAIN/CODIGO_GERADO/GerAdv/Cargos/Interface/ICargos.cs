namespace MenphisSI.GerAdv.Interface;
public partial interface ICargosService
{
    Task<IEnumerable<CargosResponseAll>> Filter(Filters.FilterCargos filter, [FromRoute, Required] string uri = "");
    Task<CargosResponse?> AddAndUpdate(Models.Cargos regCargos, [FromRoute, Required] string uri = "");
    Task<CargosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<CargosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<CargosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterCargos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}