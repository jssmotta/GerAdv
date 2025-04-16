namespace MenphisSI.GerAdv.Interface;
public partial interface IFaseService
{
    Task<IEnumerable<FaseResponse>> Filter(Filters.FilterFase filter, [FromRoute, Required] string uri = "");
    Task<FaseResponse?> AddAndUpdate(Models.Fase regFase, [FromRoute, Required] string uri = "");
    Task<FaseResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<FaseResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<FaseResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<FaseResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterFase? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}