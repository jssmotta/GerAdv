namespace MenphisSI.GerAdv.Interface;
public partial interface ITribunalService
{
    Task<IEnumerable<TribunalResponse>> Filter(Filters.FilterTribunal filter, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> AddAndUpdate(Models.Tribunal regTribunal, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<TribunalResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<TribunalResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterTribunal? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}