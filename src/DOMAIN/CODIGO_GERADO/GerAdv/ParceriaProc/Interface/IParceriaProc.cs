namespace MenphisSI.GerAdv.Interface;
public partial interface IParceriaProcService
{
    Task<IEnumerable<ParceriaProcResponse>> Filter(Filters.FilterParceriaProc filter, [FromRoute, Required] string uri = "");
    Task<ParceriaProcResponse?> AddAndUpdate(Models.ParceriaProc regParceriaProc, [FromRoute, Required] string uri = "");
    Task<ParceriaProcResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ParceriaProcResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ParceriaProcResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}