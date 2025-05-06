#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class StatusHTrabController(IStatusHTrabService statushtrabService) : ControllerBase
{
    private readonly IStatusHTrabService _statushtrabService = statushtrabService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusHTrab", "GetAll", $"max = {max}", uri);
        var result = await _statushtrabService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterStatusHTrab filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusHTrab: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _statushtrabService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("StatusHTrab: GetById called with id = {0}, {1}", id, uri);
        var result = await _statushtrabService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No StatusHTrab found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusHTrab: GetByName called with name = {0}, {1}", name, uri);
        var result = await _statushtrabService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No StatusHTrab found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusHTrab? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"StatusHTrab: GetListN called, max {max}, {filtro} uri");
        var result = await _statushtrabService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.StatusHTrab regStatusHTrab, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusHTrab", "AddAndUpdate", regStatusHTrab, uri);
        var result = await _statushtrabService.AddAndUpdate(regStatusHTrab, uri);
        if (result == null)
        {
            _logger.Warn("StatusHTrab: AddAndUpdate failed to add or update StatusHTrab, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusHTrab: Delete called with id = {0}, {2}", id, uri);
        var result = await _statushtrabService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No StatusHTrab found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}