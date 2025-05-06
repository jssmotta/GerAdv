#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PreClientesController(IPreClientesService preclientesService) : ControllerBase
{
    private readonly IPreClientesService _preclientesService = preclientesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PreClientes", "GetAll", $"max = {max}", uri);
        var result = await _preclientesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPreClientes filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("PreClientes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _preclientesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("PreClientes: GetById called with id = {0}, {1}", id, uri);
        var result = await _preclientesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No PreClientes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("PreClientes: GetByName called with name = {0}, {1}", name, uri);
        var result = await _preclientesService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No PreClientes found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterPreClientes? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"PreClientes: GetListN called, max {max}, {filtro} uri");
        var result = await _preclientesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.PreClientes regPreClientes, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PreClientes", "AddAndUpdate", regPreClientes, uri);
        var result = await _preclientesService.AddAndUpdate(regPreClientes, uri);
        if (result == null)
        {
            _logger.Warn("PreClientes: AddAndUpdate failed to add or update PreClientes, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("PreClientes: Delete called with id = {0}, {2}", id, uri);
        var result = await _preclientesService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No PreClientes found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}