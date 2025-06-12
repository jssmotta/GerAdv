namespace MenphisSI.GerAdv.Interface;
public partial interface IAlarmSMSService
{
    Task<IEnumerable<AlarmSMSResponseAll>> Filter(Filters.FilterAlarmSMS filter, [FromRoute, Required] string uri = "");
    Task<AlarmSMSResponse?> AddAndUpdate(Models.AlarmSMS regAlarmSMS, [FromRoute, Required] string uri = "");
    Task<AlarmSMSResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AlarmSMSResponseAll>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<AlarmSMSResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAlarmSMS? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}