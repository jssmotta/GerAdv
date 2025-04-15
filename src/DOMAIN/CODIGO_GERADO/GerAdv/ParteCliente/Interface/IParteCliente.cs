namespace MenphisSI.GerAdv.Interface;
public partial interface IParteClienteService
{
    Task<IEnumerable<ParteClienteResponse>> Filter(Filters.FilterParteCliente filter, [FromRoute, Required] string uri = "");
}