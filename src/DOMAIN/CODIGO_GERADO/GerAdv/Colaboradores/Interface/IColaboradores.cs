namespace MenphisSI.GerAdv.Interface;
public partial interface IColaboradoresService
{
    Task<IEnumerable<ColaboradoresResponse>> Filter(Filters.FilterColaboradores filter, [FromRoute, Required] string uri = "");
    Task<ColaboradoresResponse?> AddAndUpdate(Models.Colaboradores regColaboradores, [FromRoute, Required] string uri = "");
    Task<ColaboradoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ColaboradoresResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ColaboradoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ColaboradoresResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterColaboradores? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}