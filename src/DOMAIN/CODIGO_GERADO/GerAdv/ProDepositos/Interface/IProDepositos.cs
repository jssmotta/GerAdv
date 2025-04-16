namespace MenphisSI.GerAdv.Interface;
public partial interface IProDepositosService
{
    Task<IEnumerable<ProDepositosResponse>> Filter(Filters.FilterProDepositos filter, [FromRoute, Required] string uri = "");
    Task<ProDepositosResponse?> AddAndUpdate(Models.ProDepositos regProDepositos, [FromRoute, Required] string uri = "");
    Task<ProDepositosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProDepositosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ProDepositosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}