namespace MenphisSI.GerAdv.Interface;
public partial interface IProDespesasService
{
    Task<IEnumerable<ProDespesasResponse>> Filter(Filters.FilterProDespesas filter, [FromRoute, Required] string uri = "");
    Task<ProDespesasResponse?> AddAndUpdate(Models.ProDespesas regProDespesas, [FromRoute, Required] string uri = "");
    Task<ProDespesasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProDespesasResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProDespesasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}