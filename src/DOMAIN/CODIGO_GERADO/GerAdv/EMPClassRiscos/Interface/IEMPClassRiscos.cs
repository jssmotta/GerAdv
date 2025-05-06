namespace MenphisSI.GerAdv.Interface;
public partial interface IEMPClassRiscosService
{
    Task<IEnumerable<EMPClassRiscosResponse>> Filter(Filters.FilterEMPClassRiscos filter, [FromRoute, Required] string uri = "");
    Task<EMPClassRiscosResponse?> AddAndUpdate(Models.EMPClassRiscos regEMPClassRiscos, [FromRoute, Required] string uri = "");
    Task<EMPClassRiscosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EMPClassRiscosResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EMPClassRiscosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<EMPClassRiscosResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEMPClassRiscos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}