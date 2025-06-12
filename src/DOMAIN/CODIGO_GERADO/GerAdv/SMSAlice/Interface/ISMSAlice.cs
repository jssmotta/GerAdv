namespace MenphisSI.GerAdv.Interface;
public partial interface ISMSAliceService
{
    Task<IEnumerable<SMSAliceResponseAll>> Filter(Filters.FilterSMSAlice filter, [FromRoute, Required] string uri = "");
    Task<SMSAliceResponse?> AddAndUpdate(Models.SMSAlice regSMSAlice, [FromRoute, Required] string uri = "");
    Task<SMSAliceResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<SMSAliceResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<SMSAliceResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterSMSAlice? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}