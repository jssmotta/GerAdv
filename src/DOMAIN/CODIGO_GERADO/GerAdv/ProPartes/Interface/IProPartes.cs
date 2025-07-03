namespace MenphisSI.GerAdv.Interface;
public partial interface IProPartesService
{
    Task<IEnumerable<ProPartesResponseAll>> Filter(Filters.FilterProPartes filter, [FromRoute, Required] string uri = "");
    Task<ProPartesResponse?> AddAndUpdate(Models.ProPartes regProPartes, [FromRoute, Required] string uri = "");
    Task<ProPartesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProPartesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProPartesResponse?> Validation(Models.ProPartes regProPartes, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ProPartesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}