#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class RitoController(IRitoService ritoService) : ControllerBase
{
    private readonly IRitoService _ritoService = ritoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Rito", "GetAll", $"max = {max}", uri);
        var result = await _ritoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterRito filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Rito: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _ritoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Rito: GetById called with id = {0}, {1}", id, uri);
        var result = await _ritoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Rito found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Rito: GetByName called with name = {0}, {1}", name, uri);
        var result = await _ritoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Rito found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterRito? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Rito: GetListN called, max {max}, {filtro} uri");
        var result = await _ritoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Rito regRito, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Rito", "AddAndUpdate", regRito, uri);
        var result = await _ritoService.AddAndUpdate(regRito, uri);
        if (result == null)
        {
            _logger.Warn("Rito: AddAndUpdate failed to add or update Rito, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Rito: Delete called with id = {0}, {2}", id, uri);
        var result = await _ritoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Rito found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}