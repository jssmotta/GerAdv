#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaSemanaController(IAgendaSemanaService agendasemanaService) : ControllerBase
{
    private readonly IAgendaSemanaService _agendasemanaService = agendasemanaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AgendaSemana: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendasemanaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaSemana found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}