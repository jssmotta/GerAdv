#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadoresController(IOperadoresService operadoresService) : ControllerBase
{
    private readonly IOperadoresService _operadoresService = operadoresService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Operadores", "GetAll", $"max = {max}", uri);
        var result = await _operadoresService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOperadores filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Operadores: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _operadoresService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Operadores: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadoresService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Operadores found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Operadores: GetByName called with name = {0}, {1}", name, uri);
        var result = await _operadoresService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Operadores found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadores? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Operadores: GetListN called, max {max}, {filtro} uri");
        var result = await _operadoresService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Operadores regOperadores, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Operadores", "AddAndUpdate", regOperadores, uri);
        var result = await _operadoresService.AddAndUpdate(regOperadores, uri);
        if (result == null)
        {
            _logger.Warn("Operadores: AddAndUpdate failed to add or update Operadores, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Operadores: Delete called with id = {0}, {2}", id, uri);
        var result = await _operadoresService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Operadores found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}