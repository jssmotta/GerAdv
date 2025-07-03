#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EndTitController(IEndTitService endtitService) : ControllerBase
{
    private readonly IEndTitService _endtitService = endtitService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("EndTit", "GetAll", $"max = {max}", uri);
        var result = await _endtitService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEndTit filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("EndTit: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _endtitService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("EndTit: GetById called with id = {0}, {1}", id, uri);
        var result = await _endtitService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No EndTit found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.EndTit regEndTit, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("EndTit", "AddAndUpdate", regEndTit, uri);
        try
        {
            var result = await _endtitService.AddAndUpdate(regEndTit, uri);
            if (result == null)
            {
                _logger.Warn("EndTit: AddAndUpdate failed to add or update EndTit, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "EndTit: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("EndTit: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _endtitService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No EndTit found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "EndTit: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.EndTit regEndTit, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _endtitService.Validation(regEndTit, uri);
            if (result == null)
            {
                _logger.Warn("EndTit: Validation failed to add or update EndTit, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "EndTit: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}