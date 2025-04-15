namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadoresService
{
    Task<IEnumerable<OperadoresResponse>> Filter(Filters.FilterOperadores filter, [FromRoute, Required] string uri = "");
    Task<OperadoresResponse?> AddAndUpdate(Models.Operadores regOperadores, [FromRoute, Required] string uri = "");
    Task<OperadoresResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadoresResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<OperadoresResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OperadoresResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadores? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}