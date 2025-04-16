namespace MenphisSI.GerAdv.Interface;
public partial interface IEnderecoSistemaService
{
    Task<IEnumerable<EnderecoSistemaResponse>> Filter(Filters.FilterEnderecoSistema filter, [FromRoute, Required] string uri = "");
    Task<EnderecoSistemaResponse?> AddAndUpdate(Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri = "");
    Task<EnderecoSistemaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EnderecoSistemaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<EnderecoSistemaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}