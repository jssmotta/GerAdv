#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class StatusTarefasController(IStatusTarefasService statustarefasService) : ControllerBase
{
    private readonly IStatusTarefasService _statustarefasService = statustarefasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusTarefas", "GetAll", $"max = {max}", uri);
        var result = await _statustarefasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterStatusTarefas filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusTarefas: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _statustarefasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("StatusTarefas: GetById called with id = {0}, {1}", id, uri);
        var result = await _statustarefasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No StatusTarefas found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusTarefas: GetByName called with name = {0}, {1}", name, uri);
        var result = await _statustarefasService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No StatusTarefas found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusTarefas? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"StatusTarefas: GetListN called, max {max}, {filtro} uri");
        var result = await _statustarefasService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.StatusTarefas regStatusTarefas, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusTarefas", "AddAndUpdate", regStatusTarefas, uri);
        var result = await _statustarefasService.AddAndUpdate(regStatusTarefas, uri);
        if (result == null)
        {
            _logger.Warn("StatusTarefas: AddAndUpdate failed to add or update StatusTarefas, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusTarefas: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _statustarefasService.GetColumns(parameters, uri);
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
        _logger.Info("StatusTarefas: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _statustarefasService.UpdateColumns(parameters, uri);
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
        _logger.Info("StatusTarefas: Delete called with id = {0}, {2}", id, uri);
        var result = await _statustarefasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No StatusTarefas found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}