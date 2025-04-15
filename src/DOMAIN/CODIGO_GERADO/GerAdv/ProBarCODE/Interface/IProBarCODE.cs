namespace MenphisSI.GerAdv.Interface;
public partial interface IProBarCODEService
{
    Task<IEnumerable<ProBarCODEResponse>> Filter(Filters.FilterProBarCODE filter, [FromRoute, Required] string uri = "");
}