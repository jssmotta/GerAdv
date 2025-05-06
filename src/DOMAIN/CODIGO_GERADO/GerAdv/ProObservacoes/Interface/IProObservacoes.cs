namespace MenphisSI.GerAdv.Interface;
public partial interface IProObservacoesService
{
    Task<IEnumerable<ProObservacoesResponse>> Filter(Filters.FilterProObservacoes filter, [FromRoute, Required] string uri = "");
    Task<ProObservacoesResponse?> AddAndUpdate(Models.ProObservacoes regProObservacoes, [FromRoute, Required] string uri = "");
    Task<ProObservacoesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProObservacoesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProObservacoesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProObservacoesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProObservacoes? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}