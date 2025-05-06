namespace MenphisSI.GerAdv.Interface;
public partial interface IPreClientesService
{
    Task<IEnumerable<PreClientesResponse>> Filter(Filters.FilterPreClientes filter, [FromRoute, Required] string uri = "");
    Task<PreClientesResponse?> AddAndUpdate(Models.PreClientes regPreClientes, [FromRoute, Required] string uri = "");
    Task<PreClientesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PreClientesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PreClientesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PreClientesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPreClientes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}