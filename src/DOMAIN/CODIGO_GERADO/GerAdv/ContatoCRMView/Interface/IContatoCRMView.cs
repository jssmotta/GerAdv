namespace MenphisSI.GerAdv.Interface;
public partial interface IContatoCRMViewService
{
    Task<IEnumerable<ContatoCRMViewResponse>> Filter(Filters.FilterContatoCRMView filter, [FromRoute, Required] string uri = "");
    Task<ContatoCRMViewResponse?> AddAndUpdate(Models.ContatoCRMView regContatoCRMView, [FromRoute, Required] string uri = "");
    Task<ContatoCRMViewResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ContatoCRMViewResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ContatoCRMViewResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}