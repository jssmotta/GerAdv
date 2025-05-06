#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AlarmSMSController(IAlarmSMSService alarmsmsService) : ControllerBase
{
    private readonly IAlarmSMSService _alarmsmsService = alarmsmsService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AlarmSMS", "GetAll", $"max = {max}", uri);
        var result = await _alarmsmsService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAlarmSMS filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AlarmSMS: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _alarmsmsService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AlarmSMS: GetById called with id = {0}, {1}", id, uri);
        var result = await _alarmsmsService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AlarmSMS found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("AlarmSMS: GetByName called with name = {0}, {1}", name, uri);
        var result = await _alarmsmsService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No AlarmSMS found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAlarmSMS? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"AlarmSMS: GetListN called, max {max}, {filtro} uri");
        var result = await _alarmsmsService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AlarmSMS regAlarmSMS, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AlarmSMS", "AddAndUpdate", regAlarmSMS, uri);
        var result = await _alarmsmsService.AddAndUpdate(regAlarmSMS, uri);
        if (result == null)
        {
            _logger.Warn("AlarmSMS: AddAndUpdate failed to add or update AlarmSMS, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AlarmSMS: Delete called with id = {0}, {2}", id, uri);
        var result = await _alarmsmsService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AlarmSMS found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}