namespace MenphisSI.GerAdv.Interface;
public partial interface IEscritoriosService
{
    Task<IEnumerable<EscritoriosResponse>> Filter(Filters.FilterEscritorios filter, [FromRoute, Required] string uri = "");
    Task<EscritoriosResponse?> AddAndUpdate(Models.Escritorios regEscritorios, [FromRoute, Required] string uri = "");
    Task<EscritoriosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EscritoriosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EscritoriosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<EscritoriosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEscritorios? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}