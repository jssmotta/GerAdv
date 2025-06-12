namespace MenphisSI.GerAdv.Interface;
public partial interface IFuncaoService
{
    Task<IEnumerable<FuncaoResponseAll>> Filter(Filters.FilterFuncao filter, [FromRoute, Required] string uri = "");
    Task<FuncaoResponse?> AddAndUpdate(Models.Funcao regFuncao, [FromRoute, Required] string uri = "");
    Task<FuncaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<FuncaoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<FuncaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFuncao? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}