namespace MenphisSI.GerAdv.Interface;
public partial interface IDiario2Service
{
    Task<IEnumerable<Diario2Response>> Filter(Filters.FilterDiario2 filter, [FromRoute, Required] string uri = "");
    Task<Diario2Response?> AddAndUpdate(Models.Diario2 regDiario2, [FromRoute, Required] string uri = "");
    Task<Diario2Response?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<Diario2Response>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<Diario2Response?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<Diario2Response?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterDiario2? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}