namespace MenphisSI.GerAdv.Interface;
public partial interface IContaCorrenteService
{
    Task<IEnumerable<ContaCorrenteResponse>> Filter(Filters.FilterContaCorrente filter, [FromRoute, Required] string uri = "");
    Task<ContaCorrenteResponse?> AddAndUpdate(Models.ContaCorrente regContaCorrente, [FromRoute, Required] string uri = "");
    Task<ContaCorrenteResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ContaCorrenteResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ContaCorrenteResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}