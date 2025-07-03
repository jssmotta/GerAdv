#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OponentesController(IOponentesService oponentesService) : ControllerBase
{
    private readonly IOponentesService _oponentesService = oponentesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Oponentes", "GetAll", $"max = {max}", uri);
        var result = await _oponentesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOponentes filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Oponentes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _oponentesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Oponentes: GetById called with id = {0}, {1}", id, uri);
        var result = await _oponentesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Oponentes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentes? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Oponentes: GetListN called, max {max}, {filtro} uri");
        var result = await _oponentesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Oponentes regOponentes, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Oponentes", "AddAndUpdate", regOponentes, uri);
        try
        {
            var result = await _oponentesService.AddAndUpdate(regOponentes, uri);
            if (result == null)
            {
                _logger.Warn("Oponentes: AddAndUpdate failed to add or update Oponentes, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Oponentes: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Oponentes: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _oponentesService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Oponentes found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Oponentes: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Oponentes regOponentes, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _oponentesService.Validation(regOponentes, uri);
            if (result == null)
            {
                _logger.Warn("Oponentes: Validation failed to add or update Oponentes, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Oponentes: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}