namespace MenphisSI.GerAdv.Interface;
public partial interface IParteOponenteService
{
    Task<IEnumerable<ParteOponenteResponse>> Filter(Filters.FilterParteOponente filter, [FromRoute, Required] string uri = "");
}