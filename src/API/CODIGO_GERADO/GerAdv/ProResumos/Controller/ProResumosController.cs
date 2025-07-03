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
        //_logger.LogInfo("ProResumos", "GetAll", $"max = {max}", uri);
        var result = await _proresumosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProResumos filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProResumos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _proresumosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("ProResumos: GetById called with id = {0}, {1}", id, uri);
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
        //_logger.LogInfo("ProResumos", "AddAndUpdate", regProResumos, uri);
        try
        {
            var result = await _proresumosService.AddAndUpdate(regProResumos, uri);
            if (result == null)
            {
                _logger.Warn("ProResumos: AddAndUpdate failed to add or update ProResumos, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProResumos: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProResumos: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _proresumosService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No ProResumos found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProResumos: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.ProResumos regProResumos, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _proresumosService.Validation(regProResumos, uri);
            if (result == null)
            {
                _logger.Warn("ProResumos: Validation failed to add or update ProResumos, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProResumos: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}