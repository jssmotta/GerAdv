namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoEnderecoService
{
    Task<IEnumerable<TipoEnderecoResponseAll>> Filter(Filters.FilterTipoEndereco filter, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoResponse?> AddAndUpdate(Models.TipoEndereco regTipoEndereco, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoEnderecoResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoEnderecoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEndereco? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}