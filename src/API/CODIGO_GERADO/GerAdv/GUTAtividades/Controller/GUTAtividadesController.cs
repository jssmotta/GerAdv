#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GUTAtividadesController(IGUTAtividadesService gutatividadesService) : ControllerBase
{
    private readonly IGUTAtividadesService _gutatividadesService = gutatividadesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("GUTAtividades", "GetAll", $"max = {max}", uri);
        var result = await _gutatividadesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGUTAtividades filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("GUTAtividades: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gutatividadesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("GUTAtividades: GetById called with id = {0}, {1}", id, uri);
        var result = await _gutatividadesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GUTAtividades found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTAtividades? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"GUTAtividades: GetListN called, max {max}, {filtro} uri");
        var result = await _gutatividadesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GUTAtividades regGUTAtividades, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("GUTAtividades", "AddAndUpdate", regGUTAtividades, uri);
        try
        {
            var result = await _gutatividadesService.AddAndUpdate(regGUTAtividades, uri);
            if (result == null)
            {
                _logger.Warn("GUTAtividades: AddAndUpdate failed to add or update GUTAtividades, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTAtividades: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("GUTAtividades: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _gutatividadesService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No GUTAtividades found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTAtividades: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.GUTAtividades regGUTAtividades, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _gutatividadesService.Validation(regGUTAtividades, uri);
            if (result == null)
            {
                _logger.Warn("GUTAtividades: Validation failed to add or update GUTAtividades, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTAtividades: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}