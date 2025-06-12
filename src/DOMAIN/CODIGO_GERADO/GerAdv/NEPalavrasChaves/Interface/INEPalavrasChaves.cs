namespace MenphisSI.GerAdv.Interface;
public partial interface INEPalavrasChavesService
{
    Task<IEnumerable<NEPalavrasChavesResponseAll>> Filter(Filters.FilterNEPalavrasChaves filter, [FromRoute, Required] string uri = "");
    Task<NEPalavrasChavesResponse?> AddAndUpdate(Models.NEPalavrasChaves regNEPalavrasChaves, [FromRoute, Required] string uri = "");
    Task<NEPalavrasChavesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NEPalavrasChavesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<NEPalavrasChavesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterNEPalavrasChaves? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}