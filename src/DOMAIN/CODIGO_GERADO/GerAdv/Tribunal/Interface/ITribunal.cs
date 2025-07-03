namespace MenphisSI.GerAdv.Interface;
public partial interface ITribunalService
{
    Task<IEnumerable<TribunalResponseAll>> Filter(Filters.FilterTribunal filter, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> AddAndUpdate(Models.Tribunal regTribunal, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TribunalResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> Validation(Models.Tribunal regTribunal, [FromRoute, Required] string uri = "");
    Task<IEnumerable<TribunalResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTribunal? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}