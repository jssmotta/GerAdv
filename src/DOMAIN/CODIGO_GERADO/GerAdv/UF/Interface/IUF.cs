namespace MenphisSI.GerAdv.Interface;
public partial interface IUFService
{
    Task<IEnumerable<UFResponse>> Filter(Filters.FilterUF filter, [FromRoute, Required] string uri = "");
    Task<UFResponse?> AddAndUpdate(Models.UF regUF, [FromRoute, Required] string uri = "");
    Task<UFResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<UFResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<UFResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<UFResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterUF? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}