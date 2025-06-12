namespace MenphisSI.GerAdv.Interface;
public partial interface IJusticaService
{
    Task<IEnumerable<JusticaResponseAll>> Filter(Filters.FilterJustica filter, [FromRoute, Required] string uri = "");
    Task<JusticaResponse?> AddAndUpdate(Models.Justica regJustica, [FromRoute, Required] string uri = "");
    Task<JusticaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<JusticaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<JusticaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterJustica? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}