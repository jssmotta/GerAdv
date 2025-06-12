namespace MenphisSI.GerAdv.Interface;
public partial interface IGUTPeriodicidadeService
{
    Task<IEnumerable<GUTPeriodicidadeResponseAll>> Filter(Filters.FilterGUTPeriodicidade filter, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeResponse?> AddAndUpdate(Models.GUTPeriodicidade regGUTPeriodicidade, [FromRoute, Required] string uri = "");
    Task<GUTPeriodicidadeResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GUTPeriodicidadeResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GUTPeriodicidadeResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTPeriodicidade? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}