namespace MenphisSI.GerAdv.Interface;
public partial interface IFuncaoService
{
    Task<IEnumerable<FuncaoResponse>> Filter(Filters.FilterFuncao filter, [FromRoute, Required] string uri = "");
    Task<FuncaoResponse?> AddAndUpdate(Models.Funcao regFuncao, [FromRoute, Required] string uri = "");
    Task<FuncaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<FuncaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<FuncaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<FuncaoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFuncao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}