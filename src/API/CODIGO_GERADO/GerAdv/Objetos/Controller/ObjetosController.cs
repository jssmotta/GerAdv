#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ObjetosController(IObjetosService objetosService) : ControllerBase
{
    private readonly IObjetosService _objetosService = objetosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Objetos", "GetAll", $"max = {max}", uri);
        var result = await _objetosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterObjetos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Objetos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _objetosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Objetos: GetById called with id = {0}, {1}", id, uri);
        var result = await _objetosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Objetos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Objetos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _objetosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Objetos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterObjetos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Objetos: GetListN called, max {max}, {filtro} uri");
        var result = await _objetosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Objetos regObjetos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Objetos", "AddAndUpdate", regObjetos, uri);
        var result = await _objetosService.AddAndUpdate(regObjetos, uri);
        if (result == null)
        {
            _logger.Warn("Objetos: AddAndUpdate failed to add or update Objetos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Objetos: Delete called with id = {0}, {2}", id, uri);
        var result = await _objetosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Objetos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}