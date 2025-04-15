namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoEnderecoService
{
    Task<IEnumerable<TipoEnderecoResponse>> Filter(Filters.FilterTipoEndereco filter, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoResponse?> AddAndUpdate(Models.TipoEndereco regTipoEndereco, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoEnderecoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TipoEnderecoResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEndereco? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}