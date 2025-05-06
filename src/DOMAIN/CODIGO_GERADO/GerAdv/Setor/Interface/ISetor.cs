namespace MenphisSI.GerAdv.Interface;
public partial interface ISetorService
{
    Task<IEnumerable<SetorResponse>> Filter(Filters.FilterSetor filter, [FromRoute, Required] string uri = "");
    Task<SetorResponse?> AddAndUpdate(Models.Setor regSetor, [FromRoute, Required] string uri = "");
    Task<SetorResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<SetorResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<SetorResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<SetorResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterSetor? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}