#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TribEnderecosController(ITribEnderecosService tribenderecosService) : ControllerBase
{
    private readonly ITribEnderecosService _tribenderecosService = tribenderecosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TribEnderecos", "GetAll", $"max = {max}", uri);
        var result = await _tribenderecosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTribEnderecos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("TribEnderecos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _tribenderecosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("TribEnderecos: GetById called with id = {0}, {1}", id, uri);
        var result = await _tribenderecosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No TribEnderecos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.TribEnderecos regTribEnderecos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TribEnderecos", "AddAndUpdate", regTribEnderecos, uri);
        var result = await _tribenderecosService.AddAndUpdate(regTribEnderecos, uri);
        if (result == null)
        {
            _logger.Warn("TribEnderecos: AddAndUpdate failed to add or update TribEnderecos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("TribEnderecos: Delete called with id = {0}, {2}", id, uri);
        var result = await _tribenderecosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No TribEnderecos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}