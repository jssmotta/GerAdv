namespace MenphisSI.GerAdv.Interface;
public partial interface ITribEnderecosService
{
    Task<IEnumerable<TribEnderecosResponse>> Filter(Filters.FilterTribEnderecos filter, [FromRoute, Required] string uri = "");
    Task<TribEnderecosResponse?> AddAndUpdate(Models.TribEnderecos regTribEnderecos, [FromRoute, Required] string uri = "");
    Task<TribEnderecosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TribEnderecosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TribEnderecosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}