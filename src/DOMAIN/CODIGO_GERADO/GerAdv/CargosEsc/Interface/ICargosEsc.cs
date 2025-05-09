﻿namespace MenphisSI.GerAdv.Interface;
public partial interface ICargosEscService
{
    Task<IEnumerable<CargosEscResponse>> Filter(Filters.FilterCargosEsc filter, [FromRoute, Required] string uri = "");
    Task<CargosEscResponse?> AddAndUpdate(Models.CargosEsc regCargosEsc, [FromRoute, Required] string uri = "");
    Task<CargosEscResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<CargosEscResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<CargosEscResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<CargosEscResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterCargosEsc? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}