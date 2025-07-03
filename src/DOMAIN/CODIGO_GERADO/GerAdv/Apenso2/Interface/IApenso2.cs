namespace MenphisSI.GerAdv.Interface;
public partial interface IApenso2Service
{
    Task<IEnumerable<Apenso2ResponseAll>> Filter(Filters.FilterApenso2 filter, [FromRoute, Required] string uri = "");
    Task<Apenso2Response?> AddAndUpdate(Models.Apenso2 regApenso2, [FromRoute, Required] string uri = "");
    Task<Apenso2Response?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<Apenso2Response?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<Apenso2Response?> Validation(Models.Apenso2 regApenso2, [FromRoute, Required] string uri = "");
    Task<IEnumerable<Apenso2ResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}