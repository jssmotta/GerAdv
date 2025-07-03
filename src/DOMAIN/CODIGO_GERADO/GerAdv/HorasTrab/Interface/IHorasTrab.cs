namespace MenphisSI.GerAdv.Interface;
public partial interface IHorasTrabService
{
    Task<IEnumerable<HorasTrabResponseAll>> Filter(Filters.FilterHorasTrab filter, [FromRoute, Required] string uri = "");
    Task<HorasTrabResponse?> AddAndUpdate(Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri = "");
    Task<HorasTrabResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<HorasTrabResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<HorasTrabResponse?> Validation(Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri = "");
    Task<IEnumerable<HorasTrabResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}