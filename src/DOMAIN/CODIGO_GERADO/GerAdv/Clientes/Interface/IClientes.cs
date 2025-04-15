namespace MenphisSI.GerAdv.Interface;
public partial interface IClientesService
{
    Task<IEnumerable<ClientesResponse>> Filter(Filters.FilterClientes filter, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> AddAndUpdate(Models.Clientes regClientes, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ClientesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ClientesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}