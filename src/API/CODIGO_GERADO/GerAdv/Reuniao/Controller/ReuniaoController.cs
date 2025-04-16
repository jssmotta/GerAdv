#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ReuniaoController(IReuniaoService reuniaoService) : ControllerBase
{
    private readonly IReuniaoService _reuniaoService = reuniaoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Reuniao", "GetAll", $"max = {max}", uri);
        var result = await _reuniaoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterReuniao filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Reuniao: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _reuniaoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Reuniao: GetById called with id = {0}, {1}", id, uri);
        var result = await _reuniaoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Reuniao found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Reuniao regReuniao, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Reuniao", "AddAndUpdate", regReuniao, uri);
        var result = await _reuniaoService.AddAndUpdate(regReuniao, uri);
        if (result == null)
        {
            _logger.Warn("Reuniao: AddAndUpdate failed to add or update Reuniao, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Reuniao: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _reuniaoService.GetColumns(parameters, uri);
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
        _logger.Info("Reuniao: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _reuniaoService.UpdateColumns(parameters, uri);
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
        _logger.Info("Reuniao: Delete called with id = {0}, {2}", id, uri);
        var result = await _reuniaoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Reuniao found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}