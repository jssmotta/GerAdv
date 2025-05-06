namespace MenphisSI.GerAdv.Interface;
public partial interface IAreasJusticaService
{
    Task<IEnumerable<AreasJusticaResponse>> Filter(Filters.FilterAreasJustica filter, [FromRoute, Required] string uri = "");
    Task<AreasJusticaResponse?> AddAndUpdate(Models.AreasJustica regAreasJustica, [FromRoute, Required] string uri = "");
    Task<AreasJusticaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AreasJusticaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AreasJusticaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}