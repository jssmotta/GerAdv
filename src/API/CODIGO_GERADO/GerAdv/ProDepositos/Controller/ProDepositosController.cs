#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProDepositosController(IProDepositosService prodepositosService) : ControllerBase
{
    private readonly IProDepositosService _prodepositosService = prodepositosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProDepositos", "GetAll", $"max = {max}", uri);
        var result = await _prodepositosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProDepositos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProDepositos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _prodepositosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProDepositos: GetById called with id = {0}, {1}", id, uri);
        var result = await _prodepositosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProDepositos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProDepositos regProDepositos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProDepositos", "AddAndUpdate", regProDepositos, uri);
        var result = await _prodepositosService.AddAndUpdate(regProDepositos, uri);
        if (result == null)
        {
            _logger.Warn("ProDepositos: AddAndUpdate failed to add or update ProDepositos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProDepositos: Delete called with id = {0}, {2}", id, uri);
        var result = await _prodepositosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProDepositos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}