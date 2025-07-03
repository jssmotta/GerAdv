#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProcessosParadosController(IProcessosParadosService processosparadosService) : ControllerBase
{
    private readonly IProcessosParadosService _processosparadosService = processosparadosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProcessosParados", "GetAll", $"max = {max}", uri);
        var result = await _processosparadosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProcessosParados filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProcessosParados: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _processosparadosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("ProcessosParados: GetById called with id = {0}, {1}", id, uri);
        var result = await _processosparadosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProcessosParados found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProcessosParados regProcessosParados, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProcessosParados", "AddAndUpdate", regProcessosParados, uri);
        try
        {
            var result = await _processosparadosService.AddAndUpdate(regProcessosParados, uri);
            if (result == null)
            {
                _logger.Warn("ProcessosParados: AddAndUpdate failed to add or update ProcessosParados, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProcessosParados: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProcessosParados: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _processosparadosService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No ProcessosParados found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProcessosParados: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.ProcessosParados regProcessosParados, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _processosparadosService.Validation(regProcessosParados, uri);
            if (result == null)
            {
                _logger.Warn("ProcessosParados: Validation failed to add or update ProcessosParados, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProcessosParados: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}