namespace MenphisSI.GerAdv.Interface;
public partial interface IOperadorEMailPopupService
{
    Task<IEnumerable<OperadorEMailPopupResponse>> Filter(Filters.FilterOperadorEMailPopup filter, [FromRoute, Required] string uri = "");
    Task<OperadorEMailPopupResponse?> AddAndUpdate(Models.OperadorEMailPopup regOperadorEMailPopup, [FromRoute, Required] string uri = "");
    Task<OperadorEMailPopupResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<OperadorEMailPopupResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<OperadorEMailPopupResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<OperadorEMailPopupResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorEMailPopup? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}