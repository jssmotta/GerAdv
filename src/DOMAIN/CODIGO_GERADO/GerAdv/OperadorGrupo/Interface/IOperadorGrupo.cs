namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGrupoService
{
    Task<IEnumerable<OperadorGrupoResponse>> Filter(Filters.FilterOperadorGrupo filter, [FromRoute, Required] string uri = "");
    Task<OperadorGrupoResponse?> AddAndUpdate(Models.OperadorGrupo regOperadorGrupo, [FromRoute, Required] string uri = "");
    Task<OperadorGrupoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorGrupoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorGrupoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}