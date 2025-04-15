#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadorGruposController(IOperadorGruposService operadorgruposService) : ControllerBase
{
    private readonly IOperadorGruposService _operadorgruposService = operadorgruposService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorGrupos", "GetAll", $"max = {max}", uri);
        var result = await _operadorgruposService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOperadorGrupos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGrupos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _operadorgruposService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("OperadorGrupos: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadorgruposService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No OperadorGrupos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGrupos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _operadorgruposService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No OperadorGrupos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorGrupos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"OperadorGrupos: GetListN called, max {max}, {filtro} uri");
        var result = await _operadorgruposService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.OperadorGrupos regOperadorGrupos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorGrupos", "AddAndUpdate", regOperadorGrupos, uri);
        var result = await _operadorgruposService.AddAndUpdate(regOperadorGrupos, uri);
        if (result == null)
        {
            _logger.Warn("OperadorGrupos: AddAndUpdate failed to add or update OperadorGrupos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGrupos: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _operadorgruposService.GetColumns(parameters, uri);
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
        _logger.Info("OperadorGrupos: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _operadorgruposService.UpdateColumns(parameters, uri);
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
        _logger.Info("OperadorGrupos: Delete called with id = {0}, {2}", id, uri);
        var result = await _operadorgruposService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No OperadorGrupos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}