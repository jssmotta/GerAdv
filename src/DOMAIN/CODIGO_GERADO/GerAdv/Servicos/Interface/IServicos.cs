namespace MenphisSI.GerAdv.Interface;
public partial interface IServicosService
{
    Task<IEnumerable<ServicosResponse>> Filter(Filters.FilterServicos filter, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> AddAndUpdate(Models.Servicos regServicos, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ServicosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ServicosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterServicos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}