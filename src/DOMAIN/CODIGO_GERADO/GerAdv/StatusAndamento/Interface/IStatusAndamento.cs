namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusAndamentoService
{
    Task<IEnumerable<StatusAndamentoResponseAll>> Filter(Filters.FilterStatusAndamento filter, [FromRoute, Required] string uri = "");
    Task<StatusAndamentoResponse?> AddAndUpdate(Models.StatusAndamento regStatusAndamento, [FromRoute, Required] string uri = "");
    Task<StatusAndamentoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<StatusAndamentoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<StatusAndamentoResponse?> Validation(Models.StatusAndamento regStatusAndamento, [FromRoute, Required] string uri = "");
    Task<IEnumerable<StatusAndamentoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusAndamento? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}