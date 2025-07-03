namespace MenphisSI.GerAdv.Interface;
public partial interface IFuncionariosService
{
    Task<IEnumerable<FuncionariosResponseAll>> Filter(Filters.FilterFuncionarios filter, [FromRoute, Required] string uri = "");
    Task<FuncionariosResponse?> AddAndUpdate(Models.Funcionarios regFuncionarios, [FromRoute, Required] string uri = "");
    Task<FuncionariosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<FuncionariosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<FuncionariosResponse?> Validation(Models.Funcionarios regFuncionarios, [FromRoute, Required] string uri = "");
    Task<IEnumerable<FuncionariosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFuncionarios? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}