namespace MenphisSI.GerAdv.Interface;
public partial interface IClientesSociosService
{
    Task<IEnumerable<ClientesSociosResponse>> Filter(Filters.FilterClientesSocios filter, [FromRoute, Required] string uri = "");
    Task<ClientesSociosResponse?> AddAndUpdate(Models.ClientesSocios regClientesSocios, [FromRoute, Required] string uri = "");
    Task<ClientesSociosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ClientesSociosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ClientesSociosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ClientesSociosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientesSocios? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}