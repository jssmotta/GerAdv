namespace MenphisSI.GerAdv.Interface;
public partial interface IApensoService
{
    Task<IEnumerable<ApensoResponse>> Filter(Filters.FilterApenso filter, [FromRoute, Required] string uri = "");
    Task<ApensoResponse?> AddAndUpdate(Models.Apenso regApenso, [FromRoute, Required] string uri = "");
    Task<ApensoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ApensoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ApensoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}