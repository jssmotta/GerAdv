#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ParceriaProcController(IParceriaProcService parceriaprocService) : ControllerBase
{
    private readonly IParceriaProcService _parceriaprocService = parceriaprocService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ParceriaProc", "GetAll", $"max = {max}", uri);
        var result = await _parceriaprocService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterParceriaProc filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ParceriaProc: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _parceriaprocService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ParceriaProc: GetById called with id = {0}, {1}", id, uri);
        var result = await _parceriaprocService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ParceriaProc found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ParceriaProc regParceriaProc, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ParceriaProc", "AddAndUpdate", regParceriaProc, uri);
        var result = await _parceriaprocService.AddAndUpdate(regParceriaProc, uri);
        if (result == null)
        {
            _logger.Warn("ParceriaProc: AddAndUpdate failed to add or update ParceriaProc, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ParceriaProc: Delete called with id = {0}, {2}", id, uri);
        var result = await _parceriaprocService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ParceriaProc found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}