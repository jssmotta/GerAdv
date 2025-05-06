#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class RamalController(IRamalService ramalService) : ControllerBase
{
    private readonly IRamalService _ramalService = ramalService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Ramal", "GetAll", $"max = {max}", uri);
        var result = await _ramalService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterRamal filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Ramal: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _ramalService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Ramal: GetById called with id = {0}, {1}", id, uri);
        var result = await _ramalService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Ramal found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Ramal: GetByName called with name = {0}, {1}", name, uri);
        var result = await _ramalService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Ramal found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterRamal? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Ramal: GetListN called, max {max}, {filtro} uri");
        var result = await _ramalService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Ramal regRamal, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Ramal", "AddAndUpdate", regRamal, uri);
        var result = await _ramalService.AddAndUpdate(regRamal, uri);
        if (result == null)
        {
            _logger.Warn("Ramal: AddAndUpdate failed to add or update Ramal, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Ramal: Delete called with id = {0}, {2}", id, uri);
        var result = await _ramalService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Ramal found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}