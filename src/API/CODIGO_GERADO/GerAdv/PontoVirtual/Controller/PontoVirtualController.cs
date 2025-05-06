#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PontoVirtualController(IPontoVirtualService pontovirtualService) : ControllerBase
{
    private readonly IPontoVirtualService _pontovirtualService = pontovirtualService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PontoVirtual", "GetAll", $"max = {max}", uri);
        var result = await _pontovirtualService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPontoVirtual filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("PontoVirtual: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _pontovirtualService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("PontoVirtual: GetById called with id = {0}, {1}", id, uri);
        var result = await _pontovirtualService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No PontoVirtual found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.PontoVirtual regPontoVirtual, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PontoVirtual", "AddAndUpdate", regPontoVirtual, uri);
        var result = await _pontovirtualService.AddAndUpdate(regPontoVirtual, uri);
        if (result == null)
        {
            _logger.Warn("PontoVirtual: AddAndUpdate failed to add or update PontoVirtual, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("PontoVirtual: Delete called with id = {0}, {2}", id, uri);
        var result = await _pontovirtualService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No PontoVirtual found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}