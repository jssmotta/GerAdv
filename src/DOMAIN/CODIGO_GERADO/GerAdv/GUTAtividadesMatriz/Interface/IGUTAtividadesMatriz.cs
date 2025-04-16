namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTAtividadesMatrizService
{
    Task<IEnumerable<GUTAtividadesMatrizResponse>> Filter(Filters.FilterGUTAtividadesMatriz filter, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> AddAndUpdate(Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTAtividadesMatrizResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}