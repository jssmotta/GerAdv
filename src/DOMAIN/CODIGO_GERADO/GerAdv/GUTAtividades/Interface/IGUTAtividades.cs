namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTAtividadesService
{
    Task<IEnumerable<GUTAtividadesResponse>> Filter(Filters.FilterGUTAtividades filter, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> AddAndUpdate(Models.GUTAtividades regGUTAtividades, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTAtividadesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTAtividades? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}