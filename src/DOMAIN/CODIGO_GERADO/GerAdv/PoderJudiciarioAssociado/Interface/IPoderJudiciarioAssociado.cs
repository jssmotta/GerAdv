namespace MenphisSI.GerAdv.Interface;
public partial interface IPoderJudiciarioAssociadoService
{
    Task<IEnumerable<PoderJudiciarioAssociadoResponseAll>> Filter(Filters.FilterPoderJudiciarioAssociado filter, [FromRoute, Required] string uri = "");
    Task<PoderJudiciarioAssociadoResponse?> AddAndUpdate(Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, [FromRoute, Required] string uri = "");
    Task<PoderJudiciarioAssociadoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PoderJudiciarioAssociadoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PoderJudiciarioAssociadoResponse?> Validation(Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PoderJudiciarioAssociadoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}