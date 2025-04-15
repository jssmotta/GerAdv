namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoEnderecoSistemaService
{
    Task<IEnumerable<TipoEnderecoSistemaResponse>> Filter(Filters.FilterTipoEnderecoSistema filter, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> AddAndUpdate(Models.TipoEnderecoSistema regTipoEnderecoSistema, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoEnderecoSistemaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEnderecoSistema? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}