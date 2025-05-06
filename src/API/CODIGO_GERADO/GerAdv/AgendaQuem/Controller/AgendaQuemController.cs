#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaQuemController(IAgendaQuemService agendaquemService) : ControllerBase
{
    private readonly IAgendaQuemService _agendaquemService = agendaquemService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaQuem", "GetAll", $"max = {max}", uri);
        var result = await _agendaquemService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgendaQuem filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaQuem: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendaquemService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AgendaQuem: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendaquemService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaQuem found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AgendaQuem regAgendaQuem, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaQuem", "AddAndUpdate", regAgendaQuem, uri);
        var result = await _agendaquemService.AddAndUpdate(regAgendaQuem, uri);
        if (result == null)
        {
            _logger.Warn("AgendaQuem: AddAndUpdate failed to add or update AgendaQuem, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaQuem: Delete called with id = {0}, {2}", id, uri);
        var result = await _agendaquemService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AgendaQuem found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}