﻿namespace MenphisSI.GerAdv.Interface;
public partial interface ICargosEscClassService
{
    Task<IEnumerable<CargosEscClassResponse>> Filter(Filters.FilterCargosEscClass filter, [FromRoute, Required] string uri = "");
    Task<CargosEscClassResponse?> AddAndUpdate(Models.CargosEscClass regCargosEscClass, [FromRoute, Required] string uri = "");
    Task<CargosEscClassResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<CargosEscClassResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<CargosEscClassResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<CargosEscClassResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterCargosEscClass? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}