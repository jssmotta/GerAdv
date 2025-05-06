#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaRecordsController(IAgendaRecordsService agendarecordsService) : ControllerBase
{
    private readonly IAgendaRecordsService _agendarecordsService = agendarecordsService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaRecords", "GetAll", $"max = {max}", uri);
        var result = await _agendarecordsService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgendaRecords filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaRecords: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendarecordsService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AgendaRecords: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendarecordsService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaRecords found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AgendaRecords regAgendaRecords, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaRecords", "AddAndUpdate", regAgendaRecords, uri);
        var result = await _agendarecordsService.AddAndUpdate(regAgendaRecords, uri);
        if (result == null)
        {
            _logger.Warn("AgendaRecords: AddAndUpdate failed to add or update AgendaRecords, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaRecords: Delete called with id = {0}, {2}", id, uri);
        var result = await _agendarecordsService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AgendaRecords found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}