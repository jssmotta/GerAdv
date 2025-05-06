#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class UFController(IUFService ufService) : ControllerBase
{
    private readonly IUFService _ufService = ufService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("UF", "GetAll", $"max = {max}", uri);
        var result = await _ufService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterUF filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("UF: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _ufService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("UF: GetById called with id = {0}, {1}", id, uri);
        var result = await _ufService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No UF found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("UF: GetByName called with name = {0}, {1}", name, uri);
        var result = await _ufService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No UF found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterUF? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"UF: GetListN called, max {max}, {filtro} uri");
        var result = await _ufService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.UF regUF, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("UF", "AddAndUpdate", regUF, uri);
        var result = await _ufService.AddAndUpdate(regUF, uri);
        if (result == null)
        {
            _logger.Warn("UF: AddAndUpdate failed to add or update UF, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("UF: Delete called with id = {0}, {2}", id, uri);
        var result = await _ufService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No UF found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}