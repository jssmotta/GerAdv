namespace MenphisSI.GerAdv.Interface;
public partial interface ILigacoesService
{
    Task<IEnumerable<LigacoesResponseAll>> Filter(Filters.FilterLigacoes filter, [FromRoute, Required] string uri = "");
    Task<LigacoesResponse?> AddAndUpdate(Models.Ligacoes regLigacoes, [FromRoute, Required] string uri = "");
    Task<LigacoesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<LigacoesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<LigacoesResponse?> Validation(Models.Ligacoes regLigacoes, [FromRoute, Required] string uri = "");
    Task<IEnumerable<LigacoesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterLigacoes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}