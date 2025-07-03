namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTAtividadesService
{
    Task<IEnumerable<GUTAtividadesResponseAll>> Filter(Filters.FilterGUTAtividades filter, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> AddAndUpdate(Models.GUTAtividades regGUTAtividades, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTAtividadesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> Validation(Models.GUTAtividades regGUTAtividades, [FromRoute, Required] string uri = "");
    Task<IEnumerable<GUTAtividadesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTAtividades? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}