namespace MenphisSI.GerAdv.Interface;
public partial interface INENotasService
{
    Task<IEnumerable<NENotasResponse>> Filter(Filters.FilterNENotas filter, [FromRoute, Required] string uri = "");
    Task<NENotasResponse?> AddAndUpdate(Models.NENotas regNENotas, [FromRoute, Required] string uri = "");
    Task<NENotasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NENotasResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<NENotasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<NENotasResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterNENotas? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}