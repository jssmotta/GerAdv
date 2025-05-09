﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IProcessOutPutIDsService
{
    Task<IEnumerable<ProcessOutPutIDsResponse>> Filter(Filters.FilterProcessOutPutIDs filter, [FromRoute, Required] string uri = "");
    Task<ProcessOutPutIDsResponse?> AddAndUpdate(Models.ProcessOutPutIDs regProcessOutPutIDs, [FromRoute, Required] string uri = "");
    Task<ProcessOutPutIDsResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProcessOutPutIDsResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProcessOutPutIDsResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProcessOutPutIDsResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutPutIDs? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}