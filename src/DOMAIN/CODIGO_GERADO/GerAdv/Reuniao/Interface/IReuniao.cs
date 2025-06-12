namespace MenphisSI.GerAdv.Interface;
public partial interface IReuniaoService
{
    Task<IEnumerable<ReuniaoResponseAll>> Filter(Filters.FilterReuniao filter, [FromRoute, Required] string uri = "");
    Task<ReuniaoResponse?> AddAndUpdate(Models.Reuniao regReuniao, [FromRoute, Required] string uri = "");
    Task<ReuniaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ReuniaoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ReuniaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}