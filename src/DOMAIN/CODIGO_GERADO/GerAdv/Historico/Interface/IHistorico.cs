﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IHistoricoService
{
    Task<IEnumerable<HistoricoResponse>> Filter(Filters.FilterHistorico filter, [FromRoute, Required] string uri = "");
    Task<HistoricoResponse?> AddAndUpdate(Models.Historico regHistorico, [FromRoute, Required] string uri = "");
    Task<HistoricoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<HistoricoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<HistoricoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}