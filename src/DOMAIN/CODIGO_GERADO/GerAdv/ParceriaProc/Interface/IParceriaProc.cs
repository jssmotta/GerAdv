namespace MenphisSI.GerAdv.Interface;
public partial interface IParceriaProcService
{
    Task<IEnumerable<ParceriaProcResponseAll>> Filter(Filters.FilterParceriaProc filter, [FromRoute, Required] string uri = "");
    Task<ParceriaProcResponse?> AddAndUpdate(Models.ParceriaProc regParceriaProc, [FromRoute, Required] string uri = "");
    Task<ParceriaProcResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ParceriaProcResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ParceriaProcResponse?> Validation(Models.ParceriaProc regParceriaProc, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ParceriaProcResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}