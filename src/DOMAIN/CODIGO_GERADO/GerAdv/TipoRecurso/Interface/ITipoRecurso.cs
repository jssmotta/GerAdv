namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoRecursoService
{
    Task<IEnumerable<TipoRecursoResponse>> Filter(Filters.FilterTipoRecurso filter, [FromRoute, Required] string uri = "");
    Task<TipoRecursoResponse?> AddAndUpdate(Models.TipoRecurso regTipoRecurso, [FromRoute, Required] string uri = "");
    Task<TipoRecursoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoRecursoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TipoRecursoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoRecursoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoRecurso? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}