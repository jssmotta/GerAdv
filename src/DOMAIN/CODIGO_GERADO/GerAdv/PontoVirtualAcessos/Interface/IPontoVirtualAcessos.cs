namespace MenphisSI.GerAdv.Interface;
public partial interface IPontoVirtualAcessosService
{
    Task<IEnumerable<PontoVirtualAcessosResponseAll>> Filter(Filters.FilterPontoVirtualAcessos filter, [FromRoute, Required] string uri = "");
    Task<PontoVirtualAcessosResponse?> AddAndUpdate(Models.PontoVirtualAcessos regPontoVirtualAcessos, [FromRoute, Required] string uri = "");
    Task<PontoVirtualAcessosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PontoVirtualAcessosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PontoVirtualAcessosResponse?> Validation(Models.PontoVirtualAcessos regPontoVirtualAcessos, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PontoVirtualAcessosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}