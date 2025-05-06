namespace MenphisSI.GerAdv.Interface;
public partial interface IContatoCRMService
{
    Task<IEnumerable<ContatoCRMResponse>> Filter(Filters.FilterContatoCRM filter, [FromRoute, Required] string uri = "");
    Task<ContatoCRMResponse?> AddAndUpdate(Models.ContatoCRM regContatoCRM, [FromRoute, Required] string uri = "");
    Task<ContatoCRMResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ContatoCRMResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ContatoCRMResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}