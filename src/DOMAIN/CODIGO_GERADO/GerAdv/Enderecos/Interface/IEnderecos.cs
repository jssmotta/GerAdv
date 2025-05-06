namespace MenphisSI.GerAdv.Interface;
public partial interface IEnderecosService
{
    Task<IEnumerable<EnderecosResponse>> Filter(Filters.FilterEnderecos filter, [FromRoute, Required] string uri = "");
    Task<EnderecosResponse?> AddAndUpdate(Models.Enderecos regEnderecos, [FromRoute, Required] string uri = "");
    Task<EnderecosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EnderecosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EnderecosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<EnderecosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEnderecos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}