#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ClientesSociosController(IClientesSociosService clientessociosService) : ControllerBase
{
    private readonly IClientesSociosService _clientessociosService = clientessociosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ClientesSocios", "GetAll", $"max = {max}", uri);
        var result = await _clientessociosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterClientesSocios filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ClientesSocios: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _clientessociosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ClientesSocios: GetById called with id = {0}, {1}", id, uri);
        var result = await _clientessociosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ClientesSocios found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ClientesSocios: GetByName called with name = {0}, {1}", name, uri);
        var result = await _clientessociosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ClientesSocios found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientesSocios? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ClientesSocios: GetListN called, max {max}, {filtro} uri");
        var result = await _clientessociosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ClientesSocios regClientesSocios, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ClientesSocios", "AddAndUpdate", regClientesSocios, uri);
        var result = await _clientessociosService.AddAndUpdate(regClientesSocios, uri);
        if (result == null)
        {
            _logger.Warn("ClientesSocios: AddAndUpdate failed to add or update ClientesSocios, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ClientesSocios: Delete called with id = {0}, {2}", id, uri);
        var result = await _clientessociosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ClientesSocios found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}