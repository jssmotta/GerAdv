namespace MenphisSI.GerAdv.Interface;
public partial interface IOponentesRepLegalService
{
    Task<IEnumerable<OponentesRepLegalResponseAll>> Filter(Filters.FilterOponentesRepLegal filter, [FromRoute, Required] string uri = "");
    Task<OponentesRepLegalResponse?> AddAndUpdate(Models.OponentesRepLegal regOponentesRepLegal, [FromRoute, Required] string uri = "");
    Task<OponentesRepLegalResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OponentesRepLegalResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OponentesRepLegalResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentesRepLegal? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}