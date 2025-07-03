namespace MenphisSI.GerAdv.Interface;
public partial interface IUFService
{
    Task<IEnumerable<UFResponseAll>> Filter(Filters.FilterUF filter, [FromRoute, Required] string uri = "");
    Task<UFResponse?> AddAndUpdate(Models.UF regUF, [FromRoute, Required] string uri = "");
    Task<UFResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<UFResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<UFResponse?> Validation(Models.UF regUF, [FromRoute, Required] string uri = "");
    Task<IEnumerable<UFResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterUF? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}