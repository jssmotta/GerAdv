namespace MenphisSI.GerAdv.Interface;
public partial interface IAndCompService
{
    Task<IEnumerable<AndCompResponseAll>> Filter(Filters.FilterAndComp filter, [FromRoute, Required] string uri = "");
    Task<AndCompResponse?> AddAndUpdate(Models.AndComp regAndComp, [FromRoute, Required] string uri = "");
    Task<AndCompResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AndCompResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AndCompResponse?> Validation(Models.AndComp regAndComp, [FromRoute, Required] string uri = "");
    Task<IEnumerable<AndCompResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}