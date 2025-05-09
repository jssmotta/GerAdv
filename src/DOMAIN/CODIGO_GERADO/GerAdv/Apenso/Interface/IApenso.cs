﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IApensoService
{
    Task<IEnumerable<ApensoResponse>> Filter(Filters.FilterApenso filter, [FromRoute, Required] string uri = "");
    Task<ApensoResponse?> AddAndUpdate(Models.Apenso regApenso, [FromRoute, Required] string uri = "");
    Task<ApensoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ApensoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ApensoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}