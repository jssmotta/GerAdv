namespace MenphisSI.GerAdv.Interface;
public partial interface IPaisesService
{
    Task<IEnumerable<PaisesResponseAll>> Filter(Filters.FilterPaises filter, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> AddAndUpdate(Models.Paises regPaises, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PaisesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> Validation(Models.Paises regPaises, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PaisesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPaises? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}