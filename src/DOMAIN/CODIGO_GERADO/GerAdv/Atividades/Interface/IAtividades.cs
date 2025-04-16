namespace MenphisSI.GerAdv.Interface;
public partial interface IAtividadesService
{
    Task<IEnumerable<AtividadesResponse>> Filter(Filters.FilterAtividades filter, [FromRoute, Required] string uri = "");
    Task<AtividadesResponse?> AddAndUpdate(Models.Atividades regAtividades, [FromRoute, Required] string uri = "");
    Task<AtividadesResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AtividadesResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<AtividadesResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AtividadesResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAtividades? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}