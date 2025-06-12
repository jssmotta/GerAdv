namespace MenphisSI.GerAdv.Interface;
public partial interface ITerceirosService
{
    Task<IEnumerable<TerceirosResponseAll>> Filter(Filters.FilterTerceiros filter, [FromRoute, Required] string uri = "");
    Task<TerceirosResponse?> AddAndUpdate(Models.Terceiros regTerceiros, [FromRoute, Required] string uri = "");
    Task<TerceirosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TerceirosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TerceirosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTerceiros? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}