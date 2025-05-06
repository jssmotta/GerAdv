namespace MenphisSI.GerAdv.Interface;
public partial interface IAlertasEnviadosService
{
    Task<IEnumerable<AlertasEnviadosResponse>> Filter(Filters.FilterAlertasEnviados filter, [FromRoute, Required] string uri = "");
    Task<AlertasEnviadosResponse?> AddAndUpdate(Models.AlertasEnviados regAlertasEnviados, [FromRoute, Required] string uri = "");
    Task<AlertasEnviadosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AlertasEnviadosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AlertasEnviadosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}