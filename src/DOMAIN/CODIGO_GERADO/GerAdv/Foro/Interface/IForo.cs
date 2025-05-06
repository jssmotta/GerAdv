namespace MenphisSI.GerAdv.Interface;
public partial interface IForoService
{
    Task<IEnumerable<ForoResponse>> Filter(Filters.FilterForo filter, [FromRoute, Required] string uri = "");
    Task<ForoResponse?> AddAndUpdate(Models.Foro regForo, [FromRoute, Required] string uri = "");
    Task<ForoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ForoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ForoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ForoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterForo? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}