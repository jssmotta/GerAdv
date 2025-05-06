namespace MenphisSI.GerAdv.Interface;
public partial interface IProResumosService
{
    Task<IEnumerable<ProResumosResponse>> Filter(Filters.FilterProResumos filter, [FromRoute, Required] string uri = "");
    Task<ProResumosResponse?> AddAndUpdate(Models.ProResumos regProResumos, [FromRoute, Required] string uri = "");
    Task<ProResumosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProResumosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProResumosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}