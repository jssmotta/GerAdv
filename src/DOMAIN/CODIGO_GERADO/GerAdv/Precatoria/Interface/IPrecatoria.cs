namespace MenphisSI.GerAdv.Interface;
public partial interface IPrecatoriaService
{
    Task<IEnumerable<PrecatoriaResponseAll>> Filter(Filters.FilterPrecatoria filter, [FromRoute, Required] string uri = "");
    Task<PrecatoriaResponse?> AddAndUpdate(Models.Precatoria regPrecatoria, [FromRoute, Required] string uri = "");
    Task<PrecatoriaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PrecatoriaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PrecatoriaResponse?> Validation(Models.Precatoria regPrecatoria, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PrecatoriaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}