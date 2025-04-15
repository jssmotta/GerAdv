namespace MenphisSI.GerAdv.Interface;
public partial interface IPaisesService
{
    Task<IEnumerable<PaisesResponse>> Filter(Filters.FilterPaises filter, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> AddAndUpdate(Models.Paises regPaises, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PaisesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PaisesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPaises? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}