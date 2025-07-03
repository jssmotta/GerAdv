namespace MenphisSI.GerAdv.Interface;
public partial interface IPenhoraService
{
    Task<IEnumerable<PenhoraResponseAll>> Filter(Filters.FilterPenhora filter, [FromRoute, Required] string uri = "");
    Task<PenhoraResponse?> AddAndUpdate(Models.Penhora regPenhora, [FromRoute, Required] string uri = "");
    Task<PenhoraResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<PenhoraResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<PenhoraResponse?> Validation(Models.Penhora regPenhora, [FromRoute, Required] string uri = "");
    Task<IEnumerable<PenhoraResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterPenhora? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}