namespace MenphisSI.GerAdv.Interface;
public partial interface IPrepostosService
{
    Task<IEnumerable<PrepostosResponse>> Filter(Filters.FilterPrepostos filter, [FromRoute, Required] string uri = "");
    Task<PrepostosResponse?> AddAndUpdate(Models.Prepostos regPrepostos, [FromRoute, Required] string uri = "");
    Task<PrepostosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PrepostosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PrepostosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PrepostosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPrepostos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}