namespace MenphisSI.GerAdv.Interface;
public partial interface IContatoCRMOperadorService
{
    Task<IEnumerable<ContatoCRMOperadorResponseAll>> Filter(Filters.FilterContatoCRMOperador filter, [FromRoute, Required] string uri = "");
    Task<ContatoCRMOperadorResponse?> AddAndUpdate(Models.ContatoCRMOperador regContatoCRMOperador, [FromRoute, Required] string uri = "");
    Task<ContatoCRMOperadorResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ContatoCRMOperadorResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ContatoCRMOperadorResponse?> Validation(Models.ContatoCRMOperador regContatoCRMOperador, [FromRoute, Required] string uri = "");
    Task<IEnumerable<ContatoCRMOperadorResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
}