namespace MenphisSI.GerAdv.Interface;
public partial interface INECompromissosService
{
    Task<IEnumerable<NECompromissosResponse>> Filter(Filters.FilterNECompromissos filter, [FromRoute, Required] string uri = "");
    Task<NECompromissosResponse?> AddAndUpdate(Models.NECompromissos regNECompromissos, [FromRoute, Required] string uri = "");
    Task<NECompromissosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<NECompromissosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<NECompromissosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}