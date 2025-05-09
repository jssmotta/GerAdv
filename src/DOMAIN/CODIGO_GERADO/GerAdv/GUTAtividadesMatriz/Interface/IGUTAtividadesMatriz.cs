﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTAtividadesMatrizService
{
    Task<IEnumerable<GUTAtividadesMatrizResponse>> Filter(Filters.FilterGUTAtividadesMatriz filter, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> AddAndUpdate(Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri = "");
    Task<GUTAtividadesMatrizResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTAtividadesMatrizResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTAtividadesMatrizResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}