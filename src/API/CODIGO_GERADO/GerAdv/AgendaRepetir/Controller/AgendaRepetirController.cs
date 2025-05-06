#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaRepetirController(IAgendaRepetirService agendarepetirService) : ControllerBase
{
    private readonly IAgendaRepetirService _agendarepetirService = agendarepetirService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaRepetir", "GetAll", $"max = {max}", uri);
        var result = await _agendarepetirService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgendaRepetir filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaRepetir: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendarepetirService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AgendaRepetir: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendarepetirService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaRepetir found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AgendaRepetir regAgendaRepetir, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaRepetir", "AddAndUpdate", regAgendaRepetir, uri);
        var result = await _agendarepetirService.AddAndUpdate(regAgendaRepetir, uri);
        if (result == null)
        {
            _logger.Warn("AgendaRepetir: AddAndUpdate failed to add or update AgendaRepetir, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaRepetir: Delete called with id = {0}, {2}", id, uri);
        var result = await _agendarepetirService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AgendaRepetir found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}