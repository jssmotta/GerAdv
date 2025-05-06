#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GUTPeriodicidadeStatusController(IGUTPeriodicidadeStatusService gutperiodicidadestatusService) : ControllerBase
{
    private readonly IGUTPeriodicidadeStatusService _gutperiodicidadestatusService = gutperiodicidadestatusService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GUTPeriodicidadeStatus", "GetAll", $"max = {max}", uri);
        var result = await _gutperiodicidadestatusService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGUTPeriodicidadeStatus filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTPeriodicidadeStatus: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gutperiodicidadestatusService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("GUTPeriodicidadeStatus: GetById called with id = {0}, {1}", id, uri);
        var result = await _gutperiodicidadestatusService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GUTPeriodicidadeStatus found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GUTPeriodicidadeStatus regGUTPeriodicidadeStatus, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GUTPeriodicidadeStatus", "AddAndUpdate", regGUTPeriodicidadeStatus, uri);
        var result = await _gutperiodicidadestatusService.AddAndUpdate(regGUTPeriodicidadeStatus, uri);
        if (result == null)
        {
            _logger.Warn("GUTPeriodicidadeStatus: AddAndUpdate failed to add or update GUTPeriodicidadeStatus, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTPeriodicidadeStatus: Delete called with id = {0}, {2}", id, uri);
        var result = await _gutperiodicidadestatusService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No GUTPeriodicidadeStatus found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}