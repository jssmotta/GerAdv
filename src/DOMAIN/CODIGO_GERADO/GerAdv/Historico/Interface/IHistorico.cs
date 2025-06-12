namespace MenphisSI.GerAdv.Interface;
public partial interface IHistoricoService
{
    Task<IEnumerable<HistoricoResponseAll>> Filter(Filters.FilterHistorico filter, [FromRoute, Required] string uri = "");
    Task<HistoricoResponse?> AddAndUpdate(Models.Historico regHistorico, [FromRoute, Required] string uri = "");
    Task<HistoricoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<HistoricoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<HistoricoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}