#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class FaseController(IFaseService faseService) : ControllerBase
{
    private readonly IFaseService _faseService = faseService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Fase", "GetAll", $"max = {max}", uri);
        var result = await _faseService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterFase filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Fase: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _faseService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Fase: GetById called with id = {0}, {1}", id, uri);
        var result = await _faseService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Fase found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Fase: GetByName called with name = {0}, {1}", name, uri);
        var result = await _faseService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Fase found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterFase? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Fase: GetListN called, max {max}, {filtro} uri");
        var result = await _faseService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Fase regFase, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Fase", "AddAndUpdate", regFase, uri);
        var result = await _faseService.AddAndUpdate(regFase, uri);
        if (result == null)
        {
            _logger.Warn("Fase: AddAndUpdate failed to add or update Fase, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Fase: Delete called with id = {0}, {2}", id, uri);
        var result = await _faseService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Fase found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}