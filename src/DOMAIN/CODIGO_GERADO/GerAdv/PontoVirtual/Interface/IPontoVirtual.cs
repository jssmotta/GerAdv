namespace MenphisSI.GerAdv.Interface;
public partial interface IPontoVirtualService
{
    Task<IEnumerable<PontoVirtualResponse>> Filter(Filters.FilterPontoVirtual filter, [FromRoute, Required] string uri = "");
    Task<PontoVirtualResponse?> AddAndUpdate(Models.PontoVirtual regPontoVirtual, [FromRoute, Required] string uri = "");
    Task<PontoVirtualResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<PontoVirtualResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<PontoVirtualResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}