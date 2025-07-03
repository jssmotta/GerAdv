namespace MenphisSI.GerAdv.Interface;
public partial interface IEnderecoSistemaService
{
    Task<IEnumerable<EnderecoSistemaResponseAll>> Filter(Filters.FilterEnderecoSistema filter, [FromRoute, Required] string uri = "");
    Task<EnderecoSistemaResponse?> AddAndUpdate(Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri = "");
    Task<EnderecoSistemaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EnderecoSistemaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<EnderecoSistemaResponse?> Validation(Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri = "");
    Task<IEnumerable<EnderecoSistemaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}