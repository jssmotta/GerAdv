namespace MenphisSI.GerAdv.Interface;
public partial interface IEndTitService
{
    Task<IEnumerable<EndTitResponseAll>> Filter(Filters.FilterEndTit filter, [FromRoute, Required] string uri = "");
    Task<EndTitResponse?> AddAndUpdate(Models.EndTit regEndTit, [FromRoute, Required] string uri = "");
    Task<EndTitResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EndTitResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EndTitResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}