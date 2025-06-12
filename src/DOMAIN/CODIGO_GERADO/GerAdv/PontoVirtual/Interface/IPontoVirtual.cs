namespace MenphisSI.GerAdv.Interface;
public partial interface IPontoVirtualService
{
    Task<IEnumerable<PontoVirtualResponseAll>> Filter(Filters.FilterPontoVirtual filter, [FromRoute, Required] string uri = "");
    Task<PontoVirtualResponse?> AddAndUpdate(Models.PontoVirtual regPontoVirtual, [FromRoute, Required] string uri = "");
    Task<PontoVirtualResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PontoVirtualResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PontoVirtualResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}