namespace MenphisSI.GerAdv.Interface;
public partial interface IAtividadesService
{
    Task<IEnumerable<AtividadesResponseAll>> Filter(Filters.FilterAtividades filter, [FromRoute, Required] string uri = "");
    Task<AtividadesResponse?> AddAndUpdate(Models.Atividades regAtividades, [FromRoute, Required] string uri = "");
    Task<AtividadesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AtividadesResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AtividadesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAtividades? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}