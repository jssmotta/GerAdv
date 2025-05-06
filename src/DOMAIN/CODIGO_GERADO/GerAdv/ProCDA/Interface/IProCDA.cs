namespace MenphisSI.GerAdv.Interface;
public partial interface IProCDAService
{
    Task<IEnumerable<ProCDAResponse>> Filter(Filters.FilterProCDA filter, [FromRoute, Required] string uri = "");
    Task<ProCDAResponse?> AddAndUpdate(Models.ProCDA regProCDA, [FromRoute, Required] string uri = "");
    Task<ProCDAResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<ProCDAResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<ProCDAResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<ProCDAResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterProCDA? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}