namespace MenphisSI.GerAdv.Interface;
public partial interface IProTipoBaixaService
{
    Task<IEnumerable<ProTipoBaixaResponse>> Filter(Filters.FilterProTipoBaixa filter, [FromRoute, Required] string uri = "");
    Task<ProTipoBaixaResponse?> AddAndUpdate(Models.ProTipoBaixa regProTipoBaixa, [FromRoute, Required] string uri = "");
    Task<ProTipoBaixaResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProTipoBaixaResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProTipoBaixaResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProTipoBaixaResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProTipoBaixa? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}