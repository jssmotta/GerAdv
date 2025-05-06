namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoOrigemSucumbenciaService
{
    Task<IEnumerable<TipoOrigemSucumbenciaResponse>> Filter(Filters.FilterTipoOrigemSucumbencia filter, [FromRoute, Required] string uri = "");
    Task<TipoOrigemSucumbenciaResponse?> AddAndUpdate(Models.TipoOrigemSucumbencia regTipoOrigemSucumbencia, [FromRoute, Required] string uri = "");
    Task<TipoOrigemSucumbenciaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoOrigemSucumbenciaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoOrigemSucumbenciaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoOrigemSucumbenciaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoOrigemSucumbencia? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}