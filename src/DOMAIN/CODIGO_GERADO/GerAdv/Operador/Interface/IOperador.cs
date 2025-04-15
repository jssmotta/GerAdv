namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorService
{
    Task<OperadorResponse?> AddAndUpdate(Models.Operador regOperador, [FromRoute, Required] string uri = "");
    Task<OperadorResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<OperadorResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OperadorResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}