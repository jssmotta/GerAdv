namespace MenphisSI.GerAdv.Interface;
public partial interface IReuniaoService
{
    Task<IEnumerable<ReuniaoResponse>> Filter(Filters.FilterReuniao filter, [FromRoute, Required] string uri = "");
    Task<ReuniaoResponse?> AddAndUpdate(Models.Reuniao regReuniao, [FromRoute, Required] string uri = "");
    Task<ReuniaoResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ReuniaoResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ReuniaoResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}