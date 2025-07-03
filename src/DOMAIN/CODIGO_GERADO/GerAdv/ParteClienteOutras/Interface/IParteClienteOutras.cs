namespace MenphisSI.GerAdv.Interface;
public partial interface IParteClienteOutrasService
{
    Task<IEnumerable<ParteClienteOutrasResponseAll>> Filter(Filters.FilterParteClienteOutras filter, [FromRoute, Required] string uri = "");
    Task<ParteClienteOutrasResponse?> AddAndUpdate(Models.ParteClienteOutras regParteClienteOutras, [FromRoute, Required] string uri = "");
    Task<ParteClienteOutrasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ParteClienteOutrasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ParteClienteOutrasResponse?> Validation(Models.ParteClienteOutras regParteClienteOutras, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ParteClienteOutrasResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}