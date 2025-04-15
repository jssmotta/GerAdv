namespace MenphisSI.GerAdv.Interface;
public partial interface IAnexamentoRegistrosService
{
    Task<IEnumerable<AnexamentoRegistrosResponse>> Filter(Filters.FilterAnexamentoRegistros filter, [FromRoute, Required] string uri = "");
    Task<AnexamentoRegistrosResponse?> AddAndUpdate(Models.AnexamentoRegistros regAnexamentoRegistros, [FromRoute, Required] string uri = "");
    Task<AnexamentoRegistrosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AnexamentoRegistrosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<AnexamentoRegistrosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}