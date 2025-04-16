namespace MenphisSI.GerAdv.Interface;
public partial interface IOponentesService
{
    Task<IEnumerable<OponentesResponse>> Filter(Filters.FilterOponentes filter, [FromRoute, Required] string uri = "");
    Task<OponentesResponse?> AddAndUpdate(Models.Oponentes regOponentes, [FromRoute, Required] string uri = "");
    Task<OponentesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OponentesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<OponentesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OponentesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}