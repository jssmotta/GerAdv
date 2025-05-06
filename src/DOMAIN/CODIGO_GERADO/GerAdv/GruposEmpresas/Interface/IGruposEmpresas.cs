namespace MenphisSI.GerAdv.Interface;
public partial interface IGruposEmpresasService
{
    Task<IEnumerable<GruposEmpresasResponse>> Filter(Filters.FilterGruposEmpresas filter, [FromRoute, Required] string uri = "");
    Task<GruposEmpresasResponse?> AddAndUpdate(Models.GruposEmpresas regGruposEmpresas, [FromRoute, Required] string uri = "");
    Task<GruposEmpresasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<GruposEmpresasResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<GruposEmpresasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<GruposEmpresasResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterGruposEmpresas? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}