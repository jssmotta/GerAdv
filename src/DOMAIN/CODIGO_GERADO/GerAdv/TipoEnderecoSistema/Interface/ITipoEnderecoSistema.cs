namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoEnderecoSistemaService
{
    Task<IEnumerable<TipoEnderecoSistemaResponseAll>> Filter(Filters.FilterTipoEnderecoSistema filter, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> AddAndUpdate(Models.TipoEnderecoSistema regTipoEnderecoSistema, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoEnderecoSistemaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoSistemaResponse?> Validation(Models.TipoEnderecoSistema regTipoEnderecoSistema, [FromRoute, Required] string uri = "");
    Task<IEnumerable<TipoEnderecoSistemaResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEnderecoSistema? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}