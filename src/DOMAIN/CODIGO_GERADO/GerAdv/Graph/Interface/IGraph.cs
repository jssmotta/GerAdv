namespace MenphisSI.GerAdv.Interface;
public partial interface IGraphService
{
    Task<IEnumerable<GraphResponse>> Filter(Filters.FilterGraph filter, [FromRoute, Required] string uri = "");
    Task<GraphResponse?> AddAndUpdate(Models.Graph regGraph, [FromRoute, Required] string uri = "");
    Task<GraphResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GraphResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<GraphResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}