namespace MenphisSI.GerAdv.Interface;
public partial interface IAnexamentoRegistrosService
{
    Task<IEnumerable<AnexamentoRegistrosResponseAll>> Filter(Filters.FilterAnexamentoRegistros filter, [FromRoute, Required] string uri = "");
    Task<AnexamentoRegistrosResponse?> AddAndUpdate(Models.AnexamentoRegistros regAnexamentoRegistros, [FromRoute, Required] string uri = "");
    Task<AnexamentoRegistrosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AnexamentoRegistrosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AnexamentoRegistrosResponse?> Validation(Models.AnexamentoRegistros regAnexamentoRegistros, [FromRoute, Required] string uri = "");
    Task<IEnumerable<AnexamentoRegistrosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}