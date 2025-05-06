#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaController(IAgendaService agendaService) : ControllerBase
{
    private readonly IAgendaService _agendaService = agendaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Agenda", "GetAll", $"max = {max}", uri);
        var result = await _agendaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgenda filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Agenda: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Agenda: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Agenda found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Agenda regAgenda, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Agenda", "AddAndUpdate", regAgenda, uri);
        var result = await _agendaService.AddAndUpdate(regAgenda, uri);
        if (result == null)
        {
            _logger.Warn("Agenda: AddAndUpdate failed to add or update Agenda, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Agenda: Delete called with id = {0}, {2}", id, uri);
        var result = await _agendaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Agenda found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}