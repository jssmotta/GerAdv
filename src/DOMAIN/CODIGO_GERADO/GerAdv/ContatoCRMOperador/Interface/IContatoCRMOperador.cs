namespace MenphisSI.GerAdv.Interface;
public partial interface IContatoCRMOperadorService
{
    Task<IEnumerable<ContatoCRMOperadorResponse>> Filter(Filters.FilterContatoCRMOperador filter, [FromRoute, Required] string uri = "");
    Task<ContatoCRMOperadorResponse?> AddAndUpdate(Models.ContatoCRMOperador regContatoCRMOperador, [FromRoute, Required] string uri = "");
    Task<ContatoCRMOperadorResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ContatoCRMOperadorResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ContatoCRMOperadorResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}