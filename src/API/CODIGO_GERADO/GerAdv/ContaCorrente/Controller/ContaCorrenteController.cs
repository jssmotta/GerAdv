#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ContaCorrenteController(IContaCorrenteService contacorrenteService) : ControllerBase
{
    private readonly IContaCorrenteService _contacorrenteService = contacorrenteService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ContaCorrente", "GetAll", $"max = {max}", uri);
        var result = await _contacorrenteService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterContaCorrente filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ContaCorrente: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _contacorrenteService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ContaCorrente: GetById called with id = {0}, {1}", id, uri);
        var result = await _contacorrenteService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ContaCorrente found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ContaCorrente regContaCorrente, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ContaCorrente", "AddAndUpdate", regContaCorrente, uri);
        var result = await _contacorrenteService.AddAndUpdate(regContaCorrente, uri);
        if (result == null)
        {
            _logger.Warn("ContaCorrente: AddAndUpdate failed to add or update ContaCorrente, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ContaCorrente: Delete called with id = {0}, {2}", id, uri);
        var result = await _contacorrenteService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ContaCorrente found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}