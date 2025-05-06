namespace MenphisSI.GerAdv.Interface;
public partial interface IAcaoService
{
    Task<IEnumerable<AcaoResponse>> Filter(Filters.FilterAcao filter, [FromRoute, Required] string uri = "");
    Task<AcaoResponse?> AddAndUpdate(Models.Acao regAcao, [FromRoute, Required] string uri = "");
    Task<AcaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AcaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AcaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AcaoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAcao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}