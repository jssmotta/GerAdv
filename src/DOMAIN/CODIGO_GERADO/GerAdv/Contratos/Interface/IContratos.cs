namespace MenphisSI.GerAdv.Interface;
public partial interface IContratosService
{
    Task<IEnumerable<ContratosResponse>> Filter(Filters.FilterContratos filter, [FromRoute, Required] string uri = "");
    Task<ContratosResponse?> AddAndUpdate(Models.Contratos regContratos, [FromRoute, Required] string uri = "");
    Task<ContratosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ContratosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ContratosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}