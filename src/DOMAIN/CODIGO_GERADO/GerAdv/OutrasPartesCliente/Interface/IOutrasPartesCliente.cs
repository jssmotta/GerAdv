namespace MenphisSI.GerAdv.Interface;
public partial interface IOutrasPartesClienteService
{
    Task<IEnumerable<OutrasPartesClienteResponse>> Filter(Filters.FilterOutrasPartesCliente filter, [FromRoute, Required] string uri = "");
    Task<OutrasPartesClienteResponse?> AddAndUpdate(Models.OutrasPartesCliente regOutrasPartesCliente, [FromRoute, Required] string uri = "");
    Task<OutrasPartesClienteResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OutrasPartesClienteResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OutrasPartesClienteResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OutrasPartesClienteResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOutrasPartesCliente? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}