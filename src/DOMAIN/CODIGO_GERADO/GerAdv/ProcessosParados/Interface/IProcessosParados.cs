﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessosParadosService
{
    Task<IEnumerable<ProcessosParadosResponse>> Filter(Filters.FilterProcessosParados filter, [FromRoute, Required] string uri = "");
    Task<ProcessosParadosResponse?> AddAndUpdate(Models.ProcessosParados regProcessosParados, [FromRoute, Required] string uri = "");
    Task<ProcessosParadosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessosParadosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessosParadosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}