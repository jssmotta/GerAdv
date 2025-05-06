#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class NENotasController(INENotasService nenotasService) : ControllerBase
{
    private readonly INENotasService _nenotasService = nenotasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("NENotas", "GetAll", $"max = {max}", uri);
        var result = await _nenotasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterNENotas filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("NENotas: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _nenotasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("NENotas: GetById called with id = {0}, {1}", id, uri);
        var result = await _nenotasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No NENotas found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("NENotas: GetByName called with name = {0}, {1}", name, uri);
        var result = await _nenotasService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No NENotas found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterNENotas? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"NENotas: GetListN called, max {max}, {filtro} uri");
        var result = await _nenotasService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.NENotas regNENotas, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("NENotas", "AddAndUpdate", regNENotas, uri);
        var result = await _nenotasService.AddAndUpdate(regNENotas, uri);
        if (result == null)
        {
            _logger.Warn("NENotas: AddAndUpdate failed to add or update NENotas, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("NENotas: Delete called with id = {0}, {2}", id, uri);
        var result = await _nenotasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No NENotas found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}