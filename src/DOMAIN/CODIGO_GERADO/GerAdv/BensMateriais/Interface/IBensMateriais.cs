namespace MenphisSI.GerAdv.Interface;
public partial interface IBensMateriaisService
{
    Task<IEnumerable<BensMateriaisResponse>> Filter(Filters.FilterBensMateriais filter, [FromRoute, Required] string uri = "");
    Task<BensMateriaisResponse?> AddAndUpdate(Models.BensMateriais regBensMateriais, [FromRoute, Required] string uri = "");
    Task<BensMateriaisResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<BensMateriaisResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<BensMateriaisResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<BensMateriaisResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterBensMateriais? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}