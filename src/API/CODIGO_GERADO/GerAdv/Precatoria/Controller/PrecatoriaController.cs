#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PrecatoriaController(IPrecatoriaService precatoriaService) : ControllerBase
{
    private readonly IPrecatoriaService _precatoriaService = precatoriaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Precatoria", "GetAll", $"max = {max}", uri);
        var result = await _precatoriaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPrecatoria filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Precatoria: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _precatoriaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Precatoria: GetById called with id = {0}, {1}", id, uri);
        var result = await _precatoriaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Precatoria found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Precatoria regPrecatoria, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Precatoria", "AddAndUpdate", regPrecatoria, uri);
        var result = await _precatoriaService.AddAndUpdate(regPrecatoria, uri);
        if (result == null)
        {
            _logger.Warn("Precatoria: AddAndUpdate failed to add or update Precatoria, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Precatoria: Delete called with id = {0}, {2}", id, uri);
        var result = await _precatoriaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Precatoria found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}