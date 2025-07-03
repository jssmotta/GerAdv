namespace MenphisSI.GerAdv.Interface;
public partial interface IClientesService
{
    Task<IEnumerable<ClientesResponseAll>> Filter(Filters.FilterClientes filter, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> AddAndUpdate(Models.Clientes regClientes, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ClientesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> Validation(Models.Clientes regClientes, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ClientesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}