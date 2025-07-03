namespace MenphisSI.GerAdv.Interface;
public partial interface IGraphService
{
    Task<IEnumerable<GraphResponseAll>> Filter(Filters.FilterGraph filter, [FromRoute, Required] string uri = "");
    Task<GraphResponse?> AddAndUpdate(Models.Graph regGraph, [FromRoute, Required] string uri = "");
    Task<GraphResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GraphResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GraphResponse?> Validation(Models.Graph regGraph, [FromRoute, Required] string uri = "");
    Task<IEnumerable<GraphResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}