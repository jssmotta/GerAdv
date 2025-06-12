namespace MenphisSI.GerAdv.Interface;
public partial interface IOponentesService
{
    Task<IEnumerable<OponentesResponseAll>> Filter(Filters.FilterOponentes filter, [FromRoute, Required] string uri = "");
    Task<OponentesResponse?> AddAndUpdate(Models.Oponentes regOponentes, [FromRoute, Required] string uri = "");
    Task<OponentesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OponentesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OponentesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}