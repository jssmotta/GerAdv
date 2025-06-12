namespace MenphisSI.GerAdv.Interface;
public partial interface IBensMateriaisService
{
    Task<IEnumerable<BensMateriaisResponseAll>> Filter(Filters.FilterBensMateriais filter, [FromRoute, Required] string uri = "");
    Task<BensMateriaisResponse?> AddAndUpdate(Models.BensMateriais regBensMateriais, [FromRoute, Required] string uri = "");
    Task<BensMateriaisResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<BensMateriaisResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<BensMateriaisResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterBensMateriais? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}