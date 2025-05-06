namespace MenphisSI.GerAdv.Interface;
public partial interface IAdvogadosService
{
    Task<IEnumerable<AdvogadosResponse>> Filter(Filters.FilterAdvogados filter, [FromRoute, Required] string uri = "");
    Task<AdvogadosResponse?> AddAndUpdate(Models.Advogados regAdvogados, [FromRoute, Required] string uri = "");
    Task<AdvogadosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AdvogadosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AdvogadosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AdvogadosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAdvogados? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}