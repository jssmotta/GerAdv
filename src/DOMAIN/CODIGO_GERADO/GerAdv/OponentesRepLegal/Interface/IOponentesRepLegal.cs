namespace MenphisSI.GerAdv.Interface;
public partial interface IOponentesRepLegalService
{
    Task<IEnumerable<OponentesRepLegalResponse>> Filter(Filters.FilterOponentesRepLegal filter, [FromRoute, Required] string uri = "");
    Task<OponentesRepLegalResponse?> AddAndUpdate(Models.OponentesRepLegal regOponentesRepLegal, [FromRoute, Required] string uri = "");
    Task<OponentesRepLegalResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OponentesRepLegalResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<OponentesRepLegalResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OponentesRepLegalResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentesRepLegal? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}