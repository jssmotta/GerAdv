#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GUTMatrizController(IGUTMatrizService gutmatrizService) : ControllerBase
{
    private readonly IGUTMatrizService _gutmatrizService = gutmatrizService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("GUTMatriz", "GetAll", $"max = {max}", uri);
        var result = await _gutmatrizService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGUTMatriz filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("GUTMatriz: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gutmatrizService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("GUTMatriz: GetById called with id = {0}, {1}", id, uri);
        var result = await _gutmatrizService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GUTMatriz found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTMatriz? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"GUTMatriz: GetListN called, max {max}, {filtro} uri");
        var result = await _gutmatrizService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GUTMatriz regGUTMatriz, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("GUTMatriz", "AddAndUpdate", regGUTMatriz, uri);
        try
        {
            var result = await _gutmatrizService.AddAndUpdate(regGUTMatriz, uri);
            if (result == null)
            {
                _logger.Warn("GUTMatriz: AddAndUpdate failed to add or update GUTMatriz, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTMatriz: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("GUTMatriz: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _gutmatrizService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No GUTMatriz found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTMatriz: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.GUTMatriz regGUTMatriz, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _gutmatrizService.Validation(regGUTMatriz, uri);
            if (result == null)
            {
                _logger.Warn("GUTMatriz: Validation failed to add or update GUTMatriz, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTMatriz: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}