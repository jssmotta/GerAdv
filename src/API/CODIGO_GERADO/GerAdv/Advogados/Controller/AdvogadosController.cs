#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AdvogadosController(IAdvogadosService advogadosService) : ControllerBase
{
    private readonly IAdvogadosService _advogadosService = advogadosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Advogados", "GetAll", $"max = {max}", uri);
        var result = await _advogadosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAdvogados filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Advogados: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _advogadosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Advogados: GetById called with id = {0}, {1}", id, uri);
        var result = await _advogadosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Advogados found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Advogados: GetByName called with name = {0}, {1}", name, uri);
        var result = await _advogadosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Advogados found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAdvogados? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Advogados: GetListN called, max {max}, {filtro} uri");
        var result = await _advogadosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Advogados regAdvogados, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Advogados", "AddAndUpdate", regAdvogados, uri);
        var result = await _advogadosService.AddAndUpdate(regAdvogados, uri);
        if (result == null)
        {
            _logger.Warn("Advogados: AddAndUpdate failed to add or update Advogados, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Advogados: Delete called with id = {0}, {2}", id, uri);
        var result = await _advogadosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Advogados found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}