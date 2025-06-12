namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTAtividadesMatrizService
{
    Task<IEnumerable<GUTAtividadesMatrizResponseAll>> Filter(Filters.FilterGUTAtividadesMatriz filter, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> AddAndUpdate(Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTAtividadesMatrizResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTAtividadesMatrizResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}