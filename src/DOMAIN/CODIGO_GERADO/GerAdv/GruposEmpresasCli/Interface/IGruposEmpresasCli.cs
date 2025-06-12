namespace MenphisSI.GerAdv.Interface;
public partial interface IGruposEmpresasCliService
{
    Task<IEnumerable<GruposEmpresasCliResponseAll>> Filter(Filters.FilterGruposEmpresasCli filter, [FromRoute, Required] string uri = "");
    Task<GruposEmpresasCliResponse?> AddAndUpdate(Models.GruposEmpresasCli regGruposEmpresasCli, [FromRoute, Required] string uri = "");
    Task<GruposEmpresasCliResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GruposEmpresasCliResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GruposEmpresasCliResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}