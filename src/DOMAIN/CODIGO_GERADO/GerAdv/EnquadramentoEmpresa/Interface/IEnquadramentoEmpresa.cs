namespace MenphisSI.GerAdv.Interface;
public partial interface IEnquadramentoEmpresaService
{
    Task<IEnumerable<EnquadramentoEmpresaResponseAll>> Filter(Filters.FilterEnquadramentoEmpresa filter, [FromRoute, Required] string uri = "");
    Task<EnquadramentoEmpresaResponse?> AddAndUpdate(Models.EnquadramentoEmpresa regEnquadramentoEmpresa, [FromRoute, Required] string uri = "");
    Task<EnquadramentoEmpresaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EnquadramentoEmpresaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EnquadramentoEmpresaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEnquadramentoEmpresa? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}