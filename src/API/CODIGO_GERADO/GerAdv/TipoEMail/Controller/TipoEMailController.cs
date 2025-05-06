#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TipoEMailController(ITipoEMailService tipoemailService) : ControllerBase
{
    private readonly ITipoEMailService _tipoemailService = tipoemailService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoEMail", "GetAll", $"max = {max}", uri);
        var result = await _tipoemailService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTipoEMail filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoEMail: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _tipoemailService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("TipoEMail: GetById called with id = {0}, {1}", id, uri);
        var result = await _tipoemailService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No TipoEMail found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoEMail: GetByName called with name = {0}, {1}", name, uri);
        var result = await _tipoemailService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No TipoEMail found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoEMail? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"TipoEMail: GetListN called, max {max}, {filtro} uri");
        var result = await _tipoemailService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.TipoEMail regTipoEMail, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoEMail", "AddAndUpdate", regTipoEMail, uri);
        var result = await _tipoemailService.AddAndUpdate(regTipoEMail, uri);
        if (result == null)
        {
            _logger.Warn("TipoEMail: AddAndUpdate failed to add or update TipoEMail, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoEMail: Delete called with id = {0}, {2}", id, uri);
        var result = await _tipoemailService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No TipoEMail found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}