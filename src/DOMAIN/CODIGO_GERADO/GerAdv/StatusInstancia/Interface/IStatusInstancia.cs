namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusInstanciaService
{
    Task<IEnumerable<StatusInstanciaResponse>> Filter(Filters.FilterStatusInstancia filter, [FromRoute, Required] string uri = "");
    Task<StatusInstanciaResponse?> AddAndUpdate(Models.StatusInstancia regStatusInstancia, [FromRoute, Required] string uri = "");
    Task<StatusInstanciaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusInstanciaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<StatusInstanciaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<StatusInstanciaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusInstancia? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}