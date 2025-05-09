﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTTipoService
{
    Task<IEnumerable<GUTTipoResponse>> Filter(Filters.FilterGUTTipo filter, [FromRoute, Required] string uri = "");
    Task<GUTTipoResponse?> AddAndUpdate(Models.GUTTipo regGUTTipo, [FromRoute, Required] string uri = "");
    Task<GUTTipoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTTipoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTTipoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GUTTipoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTTipo? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}