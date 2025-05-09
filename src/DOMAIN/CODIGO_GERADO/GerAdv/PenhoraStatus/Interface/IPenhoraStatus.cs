﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IPenhoraStatusService
{
    Task<IEnumerable<PenhoraStatusResponse>> Filter(Filters.FilterPenhoraStatus filter, [FromRoute, Required] string uri = "");
    Task<PenhoraStatusResponse?> AddAndUpdate(Models.PenhoraStatus regPenhoraStatus, [FromRoute, Required] string uri = "");
    Task<PenhoraStatusResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PenhoraStatusResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PenhoraStatusResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PenhoraStatusResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPenhoraStatus? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}