namespace MenphisSI.GerAdv.Interface;
public partial interface IProPartesService
{
    Task<IEnumerable<ProPartesResponse>> Filter(Filters.FilterProPartes filter, [FromRoute, Required] string uri = "");
    Task<ProPartesResponse?> AddAndUpdate(Models.ProPartes regProPartes, [FromRoute, Required] string uri = "");
    Task<ProPartesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProPartesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ProPartesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}