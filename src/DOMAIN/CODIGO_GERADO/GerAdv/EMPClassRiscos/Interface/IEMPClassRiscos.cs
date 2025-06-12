namespace MenphisSI.GerAdv.Interface;
public partial interface IEMPClassRiscosService
{
    Task<IEnumerable<EMPClassRiscosResponseAll>> Filter(Filters.FilterEMPClassRiscos filter, [FromRoute, Required] string uri = "");
    Task<EMPClassRiscosResponse?> AddAndUpdate(Models.EMPClassRiscos regEMPClassRiscos, [FromRoute, Required] string uri = "");
    Task<EMPClassRiscosResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<EMPClassRiscosResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<EMPClassRiscosResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterEMPClassRiscos? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}