namespace MenphisSI.GerAdv.Interface;
public partial interface IViaRecebimentoService
{
    Task<IEnumerable<ViaRecebimentoResponse>> Filter(Filters.FilterViaRecebimento filter, [FromRoute, Required] string uri = "");
    Task<ViaRecebimentoResponse?> AddAndUpdate(Models.ViaRecebimento regViaRecebimento, [FromRoute, Required] string uri = "");
    Task<ViaRecebimentoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ViaRecebimentoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ViaRecebimentoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ViaRecebimentoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterViaRecebimento? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}