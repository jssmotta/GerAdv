﻿namespace MenphisSI.GerAdv.Interface;
public partial interface ITribEnderecosService
{
    Task<IEnumerable<TribEnderecosResponse>> Filter(Filters.FilterTribEnderecos filter, [FromRoute, Required] string uri = "");
    Task<TribEnderecosResponse?> AddAndUpdate(Models.TribEnderecos regTribEnderecos, [FromRoute, Required] string uri = "");
    Task<TribEnderecosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TribEnderecosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TribEnderecosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}