#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadorGrupoController(IOperadorGrupoService operadorgrupoService) : ControllerBase
{
    private readonly IOperadorGrupoService _operadorgrupoService = operadorgrupoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorGrupo", "GetAll", $"max = {max}", uri);
        var result = await _operadorgrupoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOperadorGrupo filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGrupo: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _operadorgrupoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("OperadorGrupo: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadorgrupoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No OperadorGrupo found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.OperadorGrupo regOperadorGrupo, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorGrupo", "AddAndUpdate", regOperadorGrupo, uri);
        var result = await _operadorgrupoService.AddAndUpdate(regOperadorGrupo, uri);
        if (result == null)
        {
            _logger.Warn("OperadorGrupo: AddAndUpdate failed to add or update OperadorGrupo, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGrupo: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _operadorgrupoService.GetColumns(parameters, uri);
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
        _logger.Info("OperadorGrupo: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _operadorgrupoService.UpdateColumns(parameters, uri);
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
        _logger.Info("OperadorGrupo: Delete called with id = {0}, {2}", id, uri);
        var result = await _operadorgrupoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No OperadorGrupo found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}