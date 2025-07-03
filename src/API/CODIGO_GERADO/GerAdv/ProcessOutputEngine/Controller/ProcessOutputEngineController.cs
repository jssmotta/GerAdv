#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProcessOutputEngineController(IProcessOutputEngineService processoutputengineService) : ControllerBase
{
    private readonly IProcessOutputEngineService _processoutputengineService = processoutputengineService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProcessOutputEngine", "GetAll", $"max = {max}", uri);
        var result = await _processoutputengineService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProcessOutputEngine filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProcessOutputEngine: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _processoutputengineService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("ProcessOutputEngine: GetById called with id = {0}, {1}", id, uri);
        var result = await _processoutputengineService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProcessOutputEngine found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutputEngine? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"ProcessOutputEngine: GetListN called, max {max}, {filtro} uri");
        var result = await _processoutputengineService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProcessOutputEngine regProcessOutputEngine, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProcessOutputEngine", "AddAndUpdate", regProcessOutputEngine, uri);
        try
        {
            var result = await _processoutputengineService.AddAndUpdate(regProcessOutputEngine, uri);
            if (result == null)
            {
                _logger.Warn("ProcessOutputEngine: AddAndUpdate failed to add or update ProcessOutputEngine, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProcessOutputEngine: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProcessOutputEngine: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _processoutputengineService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No ProcessOutputEngine found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProcessOutputEngine: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.ProcessOutputEngine regProcessOutputEngine, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _processoutputengineService.Validation(regProcessOutputEngine, uri);
            if (result == null)
            {
                _logger.Warn("ProcessOutputEngine: Validation failed to add or update ProcessOutputEngine, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProcessOutputEngine: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}