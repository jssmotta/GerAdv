namespace MenphisSI.GerAdv.Interface;
public partial interface ICidadeService
{
    Task<IEnumerable<CidadeResponseAll>> Filter(Filters.FilterCidade filter, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> AddAndUpdate(Models.Cidade regCidade, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<CidadeResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> Validation(Models.Cidade regCidade, [FromRoute, Required] string uri = "");
    Task<IEnumerable<CidadeResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterCidade? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}