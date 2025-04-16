#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PontoVirtualAcessosController(IPontoVirtualAcessosService pontovirtualacessosService) : ControllerBase
{
    private readonly IPontoVirtualAcessosService _pontovirtualacessosService = pontovirtualacessosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PontoVirtualAcessos", "GetAll", $"max = {max}", uri);
        var result = await _pontovirtualacessosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPontoVirtualAcessos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("PontoVirtualAcessos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _pontovirtualacessosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("PontoVirtualAcessos: GetById called with id = {0}, {1}", id, uri);
        var result = await _pontovirtualacessosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No PontoVirtualAcessos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.PontoVirtualAcessos regPontoVirtualAcessos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PontoVirtualAcessos", "AddAndUpdate", regPontoVirtualAcessos, uri);
        var result = await _pontovirtualacessosService.AddAndUpdate(regPontoVirtualAcessos, uri);
        if (result == null)
        {
            _logger.Warn("PontoVirtualAcessos: AddAndUpdate failed to add or update PontoVirtualAcessos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("PontoVirtualAcessos: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _pontovirtualacessosService.GetColumns(parameters, uri);
        if (result == null)
        {
            _logger.Warn("GetColumns: No columns found for id = {0}, {1}", parameters.Id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> UpdateColumns([FromBody] UpdateColumnsRequest parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("PontoVirtualAcessos: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _pontovirtualacessosService.UpdateColumns(parameters, uri);
        if (!result)
        {
            _logger.Warn("UpdateColumns: Failed to update columns for id = {0}, {1}", parameters.Id, uri);
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("PontoVirtualAcessos: Delete called with id = {0}, {2}", id, uri);
        var result = await _pontovirtualacessosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No PontoVirtualAcessos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}