namespace MenphisSI.GerAdv.Interface;
public partial interface IContratosService
{
    Task<IEnumerable<ContratosResponseAll>> Filter(Filters.FilterContratos filter, [FromRoute, Required] string uri = "");
    Task<ContratosResponse?> AddAndUpdate(Models.Contratos regContratos, [FromRoute, Required] string uri = "");
    Task<ContratosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ContratosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ContratosResponse?> Validation(Models.Contratos regContratos, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ContratosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}