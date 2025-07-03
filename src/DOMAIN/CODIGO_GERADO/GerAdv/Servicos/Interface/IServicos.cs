namespace MenphisSI.GerAdv.Interface;
public partial interface IServicosService
{
    Task<IEnumerable<ServicosResponseAll>> Filter(Filters.FilterServicos filter, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> AddAndUpdate(Models.Servicos regServicos, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ServicosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> Validation(Models.Servicos regServicos, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ServicosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterServicos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}