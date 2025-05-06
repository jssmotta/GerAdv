#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PrepostosController(IPrepostosService prepostosService) : ControllerBase
{
    private readonly IPrepostosService _prepostosService = prepostosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Prepostos", "GetAll", $"max = {max}", uri);
        var result = await _prepostosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPrepostos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Prepostos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _prepostosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Prepostos: GetById called with id = {0}, {1}", id, uri);
        var result = await _prepostosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Prepostos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Prepostos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _prepostosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Prepostos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterPrepostos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Prepostos: GetListN called, max {max}, {filtro} uri");
        var result = await _prepostosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Prepostos regPrepostos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Prepostos", "AddAndUpdate", regPrepostos, uri);
        var result = await _prepostosService.AddAndUpdate(regPrepostos, uri);
        if (result == null)
        {
            _logger.Warn("Prepostos: AddAndUpdate failed to add or update Prepostos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Prepostos: Delete called with id = {0}, {2}", id, uri);
        var result = await _prepostosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Prepostos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}