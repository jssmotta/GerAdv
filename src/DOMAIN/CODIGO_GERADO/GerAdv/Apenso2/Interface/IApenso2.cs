namespace MenphisSI.GerAdv.Interface;
public partial interface IApenso2Service
{
    Task<IEnumerable<Apenso2Response>> Filter(Filters.FilterApenso2 filter, [FromRoute, Required] string uri = "");
    Task<Apenso2Response?> AddAndUpdate(Models.Apenso2 regApenso2, [FromRoute, Required] string uri = "");
    Task<Apenso2Response?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<Apenso2Response>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<Apenso2Response?> Delete(int id, [FromRoute, Required] string uri = "");
}