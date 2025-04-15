namespace MenphisSI.GerAdv.Interface;
public partial interface IRamalService
{
    Task<IEnumerable<RamalResponse>> Filter(Filters.FilterRamal filter, [FromRoute, Required] string uri = "");
    Task<RamalResponse?> AddAndUpdate(Models.Ramal regRamal, [FromRoute, Required] string uri = "");
    Task<RamalResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<RamalResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<RamalResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<RamalResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterRamal? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}