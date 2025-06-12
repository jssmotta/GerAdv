namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorEMailPopupService
{
    Task<IEnumerable<OperadorEMailPopupResponseAll>> Filter(Filters.FilterOperadorEMailPopup filter, [FromRoute, Required] string uri = "");
    Task<OperadorEMailPopupResponse?> AddAndUpdate(Models.OperadorEMailPopup regOperadorEMailPopup, [FromRoute, Required] string uri = "");
    Task<OperadorEMailPopupResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorEMailPopupResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorEMailPopupResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorEMailPopup? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}