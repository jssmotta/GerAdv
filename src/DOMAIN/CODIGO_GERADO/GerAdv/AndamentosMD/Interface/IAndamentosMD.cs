namespace MenphisSI.GerAdv.Interface;
public partial interface IAndamentosMDService
{
    Task<IEnumerable<AndamentosMDResponseAll>> Filter(Filters.FilterAndamentosMD filter, [FromRoute, Required] string uri = "");
    Task<AndamentosMDResponse?> AddAndUpdate(Models.AndamentosMD regAndamentosMD, [FromRoute, Required] string uri = "");
    Task<AndamentosMDResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AndamentosMDResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AndamentosMDResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAndamentosMD? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}