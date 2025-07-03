#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProProcuradoresController(IProProcuradoresService proprocuradoresService) : ControllerBase
{
    private readonly IProProcuradoresService _proprocuradoresService = proprocuradoresService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProProcuradores", "GetAll", $"max = {max}", uri);
        var result = await _proprocuradoresService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProProcuradores filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProProcuradores: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _proprocuradoresService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("ProProcuradores: GetById called with id = {0}, {1}", id, uri);
        var result = await _proprocuradoresService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProProcuradores found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProProcuradores? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"ProProcuradores: GetListN called, max {max}, {filtro} uri");
        var result = await _proprocuradoresService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProProcuradores regProProcuradores, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProProcuradores", "AddAndUpdate", regProProcuradores, uri);
        try
        {
            var result = await _proprocuradoresService.AddAndUpdate(regProProcuradores, uri);
            if (result == null)
            {
                _logger.Warn("ProProcuradores: AddAndUpdate failed to add or update ProProcuradores, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProProcuradores: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProProcuradores: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _proprocuradoresService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No ProProcuradores found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProProcuradores: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.ProProcuradores regProProcuradores, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _proprocuradoresService.Validation(regProProcuradores, uri);
            if (result == null)
            {
                _logger.Warn("ProProcuradores: Validation failed to add or update ProProcuradores, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProProcuradores: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}