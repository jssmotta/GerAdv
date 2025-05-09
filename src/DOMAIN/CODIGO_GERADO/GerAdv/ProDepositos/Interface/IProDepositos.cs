﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IProDepositosService
{
    Task<IEnumerable<ProDepositosResponse>> Filter(Filters.FilterProDepositos filter, [FromRoute, Required] string uri = "");
    Task<ProDepositosResponse?> AddAndUpdate(Models.ProDepositos regProDepositos, [FromRoute, Required] string uri = "");
    Task<ProDepositosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProDepositosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProDepositosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}