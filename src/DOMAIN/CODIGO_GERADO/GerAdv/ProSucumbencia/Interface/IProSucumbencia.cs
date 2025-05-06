namespace MenphisSI.GerAdv.Interface;
public partial interface IProSucumbenciaService
{
    Task<IEnumerable<ProSucumbenciaResponse>> Filter(Filters.FilterProSucumbencia filter, [FromRoute, Required] string uri = "");
    Task<ProSucumbenciaResponse?> AddAndUpdate(Models.ProSucumbencia regProSucumbencia, [FromRoute, Required] string uri = "");
    Task<ProSucumbenciaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProSucumbenciaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProSucumbenciaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProSucumbenciaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProSucumbencia? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}