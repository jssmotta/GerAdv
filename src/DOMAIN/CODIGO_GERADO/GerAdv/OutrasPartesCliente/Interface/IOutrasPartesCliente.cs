namespace MenphisSI.GerAdv.Interface;
public partial interface IOutrasPartesClienteService
{
    Task<IEnumerable<OutrasPartesClienteResponseAll>> Filter(Filters.FilterOutrasPartesCliente filter, [FromRoute, Required] string uri = "");
    Task<OutrasPartesClienteResponse?> AddAndUpdate(Models.OutrasPartesCliente regOutrasPartesCliente, [FromRoute, Required] string uri = "");
    Task<OutrasPartesClienteResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OutrasPartesClienteResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OutrasPartesClienteResponse?> Validation(Models.OutrasPartesCliente regOutrasPartesCliente, [FromRoute, Required] string uri = "");
    Task<IEnumerable<OutrasPartesClienteResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOutrasPartesCliente? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}