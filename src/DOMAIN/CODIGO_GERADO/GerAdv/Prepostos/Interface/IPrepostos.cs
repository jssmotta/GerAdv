namespace MenphisSI.GerAdv.Interface;
public partial interface IPrepostosService
{
    Task<IEnumerable<PrepostosResponseAll>> Filter(Filters.FilterPrepostos filter, [FromRoute, Required] string uri = "");
    Task<PrepostosResponse?> AddAndUpdate(Models.Prepostos regPrepostos, [FromRoute, Required] string uri = "");
    Task<PrepostosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PrepostosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PrepostosResponse?> Validation(Models.Prepostos regPrepostos, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PrepostosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPrepostos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}