namespace MenphisSI.GerAdv.Interface;
public partial interface IAuditor4KService
{
    Task<IEnumerable<Auditor4KResponse>> Filter(Filters.FilterAuditor4K filter, [FromRoute, Required] string uri = "");
    Task<Auditor4KResponse?> AddAndUpdate(Models.Auditor4K regAuditor4K, [FromRoute, Required] string uri = "");
    Task<Auditor4KResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<Auditor4KResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<Auditor4KResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<Auditor4KResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAuditor4K? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}