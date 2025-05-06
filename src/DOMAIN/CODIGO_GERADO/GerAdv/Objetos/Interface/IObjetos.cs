namespace MenphisSI.GerAdv.Interface;
public partial interface IObjetosService
{
    Task<IEnumerable<ObjetosResponse>> Filter(Filters.FilterObjetos filter, [FromRoute, Required] string uri = "");
    Task<ObjetosResponse?> AddAndUpdate(Models.Objetos regObjetos, [FromRoute, Required] string uri = "");
    Task<ObjetosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ObjetosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ObjetosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ObjetosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterObjetos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}