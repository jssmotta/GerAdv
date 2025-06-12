namespace MenphisSI.GerAdv.Interface;
public partial interface IRecadosService
{
    Task<IEnumerable<RecadosResponseAll>> Filter(Filters.FilterRecados filter, [FromRoute, Required] string uri = "");
    Task<RecadosResponse?> AddAndUpdate(Models.Recados regRecados, [FromRoute, Required] string uri = "");
    Task<RecadosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<RecadosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<RecadosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
}