namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorGrupoService
{
    Task<IEnumerable<OperadorGrupoResponse>> Filter(Filters.FilterOperadorGrupo filter, [FromRoute, Required] string uri = "");
    Task<OperadorGrupoResponse?> AddAndUpdate(Models.OperadorGrupo regOperadorGrupo, [FromRoute, Required] string uri = "");
    Task<OperadorGrupoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorGrupoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<OperadorGrupoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}