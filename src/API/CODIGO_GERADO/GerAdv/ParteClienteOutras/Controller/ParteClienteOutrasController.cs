#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ParteClienteOutrasController(IParteClienteOutrasService parteclienteoutrasService) : ControllerBase
{
    private readonly IParteClienteOutrasService _parteclienteoutrasService = parteclienteoutrasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ParteClienteOutras", "GetAll", $"max = {max}", uri);
        var result = await _parteclienteoutrasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterParteClienteOutras filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ParteClienteOutras: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _parteclienteoutrasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ParteClienteOutras: GetById called with id = {0}, {1}", id, uri);
        var result = await _parteclienteoutrasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ParteClienteOutras found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ParteClienteOutras regParteClienteOutras, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ParteClienteOutras", "AddAndUpdate", regParteClienteOutras, uri);
        var result = await _parteclienteoutrasService.AddAndUpdate(regParteClienteOutras, uri);
        if (result == null)
        {
            _logger.Warn("ParteClienteOutras: AddAndUpdate failed to add or update ParteClienteOutras, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ParteClienteOutras: Delete called with id = {0}, {2}", id, uri);
        var result = await _parteclienteoutrasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ParteClienteOutras found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}