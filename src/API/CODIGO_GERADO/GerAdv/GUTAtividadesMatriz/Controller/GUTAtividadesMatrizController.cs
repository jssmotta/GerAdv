#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GUTAtividadesMatrizController(IGUTAtividadesMatrizService gutatividadesmatrizService) : ControllerBase
{
    private readonly IGUTAtividadesMatrizService _gutatividadesmatrizService = gutatividadesmatrizService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("GUTAtividadesMatriz", "GetAll", $"max = {max}", uri);
        var result = await _gutatividadesmatrizService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGUTAtividadesMatriz filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("GUTAtividadesMatriz: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gutatividadesmatrizService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("GUTAtividadesMatriz: GetById called with id = {0}, {1}", id, uri);
        var result = await _gutatividadesmatrizService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GUTAtividadesMatriz found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("GUTAtividadesMatriz", "AddAndUpdate", regGUTAtividadesMatriz, uri);
        try
        {
            var result = await _gutatividadesmatrizService.AddAndUpdate(regGUTAtividadesMatriz, uri);
            if (result == null)
            {
                _logger.Warn("GUTAtividadesMatriz: AddAndUpdate failed to add or update GUTAtividadesMatriz, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTAtividadesMatriz: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("GUTAtividadesMatriz: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _gutatividadesmatrizService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No GUTAtividadesMatriz found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTAtividadesMatriz: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.GUTAtividadesMatriz regGUTAtividadesMatriz, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _gutatividadesmatrizService.Validation(regGUTAtividadesMatriz, uri);
            if (result == null)
            {
                _logger.Warn("GUTAtividadesMatriz: Validation failed to add or update GUTAtividadesMatriz, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GUTAtividadesMatriz: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}