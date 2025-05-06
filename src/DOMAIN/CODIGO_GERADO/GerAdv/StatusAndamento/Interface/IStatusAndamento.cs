namespace MenphisSI.GerAdv.Interface;
public partial interface IStatusAndamentoService
{
    Task<IEnumerable<StatusAndamentoResponse>> Filter(Filters.FilterStatusAndamento filter, [FromRoute, Required] string uri = "");
    Task<StatusAndamentoResponse?> AddAndUpdate(Models.StatusAndamento regStatusAndamento, [FromRoute, Required] string uri = "");
    Task<StatusAndamentoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<StatusAndamentoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<StatusAndamentoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<StatusAndamentoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusAndamento? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}