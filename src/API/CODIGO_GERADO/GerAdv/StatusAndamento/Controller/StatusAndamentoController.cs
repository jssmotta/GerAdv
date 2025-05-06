#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class StatusAndamentoController(IStatusAndamentoService statusandamentoService) : ControllerBase
{
    private readonly IStatusAndamentoService _statusandamentoService = statusandamentoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusAndamento", "GetAll", $"max = {max}", uri);
        var result = await _statusandamentoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterStatusAndamento filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusAndamento: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _statusandamentoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("StatusAndamento: GetById called with id = {0}, {1}", id, uri);
        var result = await _statusandamentoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No StatusAndamento found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusAndamento: GetByName called with name = {0}, {1}", name, uri);
        var result = await _statusandamentoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No StatusAndamento found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusAndamento? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"StatusAndamento: GetListN called, max {max}, {filtro} uri");
        var result = await _statusandamentoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.StatusAndamento regStatusAndamento, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusAndamento", "AddAndUpdate", regStatusAndamento, uri);
        var result = await _statusandamentoService.AddAndUpdate(regStatusAndamento, uri);
        if (result == null)
        {
            _logger.Warn("StatusAndamento: AddAndUpdate failed to add or update StatusAndamento, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusAndamento: Delete called with id = {0}, {2}", id, uri);
        var result = await _statusandamentoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No StatusAndamento found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}