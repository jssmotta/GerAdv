namespace MenphisSI.GerAdv.Interface;
public partial interface ISituacaoService
{
    Task<IEnumerable<SituacaoResponse>> Filter(Filters.FilterSituacao filter, [FromRoute, Required] string uri = "");
    Task<SituacaoResponse?> AddAndUpdate(Models.Situacao regSituacao, [FromRoute, Required] string uri = "");
    Task<SituacaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<SituacaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<SituacaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}