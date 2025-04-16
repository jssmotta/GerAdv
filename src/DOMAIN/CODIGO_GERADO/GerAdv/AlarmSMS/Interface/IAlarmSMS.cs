namespace MenphisSI.GerAdv.Interface;
public partial interface IAlarmSMSService
{
    Task<IEnumerable<AlarmSMSResponse>> Filter(Filters.FilterAlarmSMS filter, [FromRoute, Required] string uri = "");
    Task<AlarmSMSResponse?> AddAndUpdate(Models.AlarmSMS regAlarmSMS, [FromRoute, Required] string uri = "");
    Task<AlarmSMSResponse?> GetById(int id, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<IEnumerable<AlarmSMSResponse>> GetAll(int max, [FromRoute, Required] string uri = "", CancellationToken token = default);
    Task<bool> UpdateColumns(UpdateColumnsRequest columns, [FromRoute, Required] string uri = "");
    Task<GetColumnsResponse?> GetColumns(GetColumns parameters, [FromRoute, Required] string uri = "");
    Task<AlarmSMSResponse?> Delete(int id, [FromRoute, Required] string uri = "");
    Task<AlarmSMSResponse?> GetByName(string name, [FromRoute, Required] string uri = "");
    Task<IEnumerable<NomeID>> GetListN([FromQuery] int max, [FromBody] Filters.FilterAlarmSMS? filter, [FromRoute, Required] string uri = "", CancellationToken token = default);
}