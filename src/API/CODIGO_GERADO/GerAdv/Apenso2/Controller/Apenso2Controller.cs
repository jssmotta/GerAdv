#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class Apenso2Controller(IApenso2Service apenso2Service) : ControllerBase
{
    private readonly IApenso2Service _apenso2Service = apenso2Service;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Apenso2", "GetAll", $"max = {max}", uri);
        var result = await _apenso2Service.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterApenso2 filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Apenso2: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _apenso2Service.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Apenso2: GetById called with id = {0}, {1}", id, uri);
        var result = await _apenso2Service.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Apenso2 found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Apenso2 regApenso2, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Apenso2", "AddAndUpdate", regApenso2, uri);
        var result = await _apenso2Service.AddAndUpdate(regApenso2, uri);
        if (result == null)
        {
            _logger.Warn("Apenso2: AddAndUpdate failed to add or update Apenso2, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Apenso2: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _apenso2Service.GetColumns(parameters, uri);
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
        _logger.Info("Apenso2: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _apenso2Service.UpdateColumns(parameters, uri);
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
        _logger.Info("Apenso2: Delete called with id = {0}, {2}", id, uri);
        var result = await _apenso2Service.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Apenso2 found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}