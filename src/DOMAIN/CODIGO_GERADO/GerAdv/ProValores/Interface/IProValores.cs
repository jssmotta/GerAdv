namespace MenphisSI.GerAdv.Interface;
public partial interface IProValoresService
{
    Task<IEnumerable<ProValoresResponseAll>> Filter(Filters.FilterProValores filter, [FromRoute, Required] string uri = "");
    Task<ProValoresResponse?> AddAndUpdate(Models.ProValores regProValores, [FromRoute, Required] string uri = "");
    Task<ProValoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProValoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProValoresResponse?> Validation(Models.ProValores regProValores, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ProValoresResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}