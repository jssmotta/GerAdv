namespace MenphisSI.GerAdv.Interface;
public partial interface IAlertasService
{
    Task<IEnumerable<AlertasResponseAll>> Filter(Filters.FilterAlertas filter, [FromRoute, Required] string uri = "");
    Task<AlertasResponse?> AddAndUpdate(Models.Alertas regAlertas, [FromRoute, Required] string uri = "");
    Task<AlertasResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AlertasResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AlertasResponse?> Validation(Models.Alertas regAlertas, [FromRoute, Required] string uri = "");
    Task<IEnumerable<AlertasResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAlertas? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}