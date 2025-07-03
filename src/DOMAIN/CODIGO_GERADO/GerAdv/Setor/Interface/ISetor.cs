namespace MenphisSI.GerAdv.Interface;
public partial interface ISetorService
{
    Task<IEnumerable<SetorResponseAll>> Filter(Filters.FilterSetor filter, [FromRoute, Required] string uri = "");
    Task<SetorResponse?> AddAndUpdate(Models.Setor regSetor, [FromRoute, Required] string uri = "");
    Task<SetorResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<SetorResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<SetorResponse?> Validation(Models.Setor regSetor, [FromRoute, Required] string uri = "");
    Task<IEnumerable<SetorResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterSetor? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}