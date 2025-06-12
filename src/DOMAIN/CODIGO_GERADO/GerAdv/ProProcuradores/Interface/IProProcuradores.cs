namespace MenphisSI.GerAdv.Interface;
public partial interface IProProcuradoresService
{
    Task<IEnumerable<ProProcuradoresResponseAll>> Filter(Filters.FilterProProcuradores filter, [FromRoute, Required] string uri = "");
    Task<ProProcuradoresResponse?> AddAndUpdate(Models.ProProcuradores regProProcuradores, [FromRoute, Required] string uri = "");
    Task<ProProcuradoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProProcuradoresResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProProcuradoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProProcuradores? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}