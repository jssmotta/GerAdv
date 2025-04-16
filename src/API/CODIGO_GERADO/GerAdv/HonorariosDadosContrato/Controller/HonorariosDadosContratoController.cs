#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class HonorariosDadosContratoController(IHonorariosDadosContratoService honorariosdadoscontratoService) : ControllerBase
{
    private readonly IHonorariosDadosContratoService _honorariosdadoscontratoService = honorariosdadoscontratoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("HonorariosDadosContrato", "GetAll", $"max = {max}", uri);
        var result = await _honorariosdadoscontratoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterHonorariosDadosContrato filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("HonorariosDadosContrato: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _honorariosdadoscontratoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("HonorariosDadosContrato: GetById called with id = {0}, {1}", id, uri);
        var result = await _honorariosdadoscontratoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No HonorariosDadosContrato found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.HonorariosDadosContrato regHonorariosDadosContrato, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("HonorariosDadosContrato", "AddAndUpdate", regHonorariosDadosContrato, uri);
        var result = await _honorariosdadoscontratoService.AddAndUpdate(regHonorariosDadosContrato, uri);
        if (result == null)
        {
            _logger.Warn("HonorariosDadosContrato: AddAndUpdate failed to add or update HonorariosDadosContrato, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("HonorariosDadosContrato: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _honorariosdadoscontratoService.GetColumns(parameters, uri);
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
        _logger.Info("HonorariosDadosContrato: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _honorariosdadoscontratoService.UpdateColumns(parameters, uri);
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
        _logger.Info("HonorariosDadosContrato: Delete called with id = {0}, {2}", id, uri);
        var result = await _honorariosdadoscontratoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No HonorariosDadosContrato found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}