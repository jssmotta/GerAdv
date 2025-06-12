namespace MenphisSI.GerAdv.Interface;
public partial interface ITipoEMailService
{
    Task<IEnumerable<TipoEMailResponseAll>> Filter(Filters.FilterTipoEMail filter, [FromRoute, Required] string uri = "");
    Task<TipoEMailResponse?> AddAndUpdate(Models.TipoEMail regTipoEMail, [FromRoute, Required] string uri = "");
    Task<TipoEMailResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TipoEMailResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<TipoEMailResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEMail? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}