#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProResumosController(IProResumosService proresumosService) : ControllerBase
{
    private readonly IProResumosService _proresumosService = proresumosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProResumos", "GetAll", $"max = {max}", uri);
        var result = await _proresumosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProResumos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProResumos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _proresumosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProResumos: GetById called with id = {0}, {1}", id, uri);
        var result = await _proresumosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProResumos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProResumos regProResumos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProResumos", "AddAndUpdate", regProResumos, uri);
        var result = await _proresumosService.AddAndUpdate(regProResumos, uri);
        if (result == null)
        {
            _logger.Warn("ProResumos: AddAndUpdate failed to add or update ProResumos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("ProResumos: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _proresumosService.GetColumns(parameters, uri);
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
        _logger.Info("ProResumos: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _proresumosService.UpdateColumns(parameters, uri);
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
        _logger.Info("ProResumos: Delete called with id = {0}, {2}", id, uri);
        var result = await _proresumosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProResumos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}