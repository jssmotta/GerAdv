#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProValoresController(IProValoresService provaloresService) : ControllerBase
{
    private readonly IProValoresService _provaloresService = provaloresService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProValores", "GetAll", $"max = {max}", uri);
        var result = await _provaloresService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProValores filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProValores: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _provaloresService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProValores: GetById called with id = {0}, {1}", id, uri);
        var result = await _provaloresService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProValores found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProValores regProValores, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProValores", "AddAndUpdate", regProValores, uri);
        var result = await _provaloresService.AddAndUpdate(regProValores, uri);
        if (result == null)
        {
            _logger.Warn("ProValores: AddAndUpdate failed to add or update ProValores, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProValores: Delete called with id = {0}, {2}", id, uri);
        var result = await _provaloresService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProValores found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}