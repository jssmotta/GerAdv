namespace MenphisSI.GerAdv.Interface;
public partial interface IHorasTrabService
{
    Task<IEnumerable<HorasTrabResponse>> Filter(Filters.FilterHorasTrab filter, [FromRoute, Required] string uri = "");
    Task<HorasTrabResponse?> AddAndUpdate(Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri = "");
    Task<HorasTrabResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<HorasTrabResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<HorasTrabResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}