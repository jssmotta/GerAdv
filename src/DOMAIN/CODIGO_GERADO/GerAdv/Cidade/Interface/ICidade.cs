namespace MenphisSI.GerAdv.Interface;
public partial interface ICidadeService
{
    Task<IEnumerable<CidadeResponse>> Filter(Filters.FilterCidade filter, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> AddAndUpdate(Models.Cidade regCidade, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<CidadeResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<CidadeResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterCidade? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}