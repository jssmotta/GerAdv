namespace MenphisSI.GerAdv.Interface;
public partial interface IFuncionariosService
{
    Task<IEnumerable<FuncionariosResponse>> Filter(Filters.FilterFuncionarios filter, [FromRoute, Required] string uri = "");
    Task<FuncionariosResponse?> AddAndUpdate(Models.Funcionarios regFuncionarios, [FromRoute, Required] string uri = "");
    Task<FuncionariosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<FuncionariosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<FuncionariosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<FuncionariosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFuncionarios? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}