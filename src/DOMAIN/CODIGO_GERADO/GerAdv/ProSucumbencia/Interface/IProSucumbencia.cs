namespace MenphisSI.GerAdv.Interface;
public partial interface IProSucumbenciaService
{
    Task<IEnumerable<ProSucumbenciaResponseAll>> Filter(Filters.FilterProSucumbencia filter, [FromRoute, Required] string uri = "");
    Task<ProSucumbenciaResponse?> AddAndUpdate(Models.ProSucumbencia regProSucumbencia, [FromRoute, Required] string uri = "");
    Task<ProSucumbenciaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProSucumbenciaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProSucumbenciaResponse?> Validation(Models.ProSucumbencia regProSucumbencia, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ProSucumbenciaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProSucumbencia? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}