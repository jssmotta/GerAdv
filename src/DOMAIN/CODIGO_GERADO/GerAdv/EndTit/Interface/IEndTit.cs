namespace MenphisSI.GerAdv.Interface;
public partial interface IEndTitService
{
    Task<IEnumerable<EndTitResponse>> Filter(Filters.FilterEndTit filter, [FromRoute, Required] string uri = "");
    Task<EndTitResponse?> AddAndUpdate(Models.EndTit regEndTit, [FromRoute, Required] string uri = "");
    Task<EndTitResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EndTitResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<EndTitResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}