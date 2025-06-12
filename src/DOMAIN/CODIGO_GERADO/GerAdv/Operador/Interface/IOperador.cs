namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorService
{
    Task<IEnumerable<OperadorResponseAll>> Filter(Filters.FilterOperador filter, [FromRoute, Required] string uri = "");
    Task<OperadorResponse?> AddAndUpdate(Models.Operador regOperador, [FromRoute, Required] string uri = "");
    Task<OperadorResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperador? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}