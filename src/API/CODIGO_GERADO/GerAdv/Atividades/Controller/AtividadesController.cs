#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AtividadesController(IAtividadesService atividadesService) : ControllerBase
{
    private readonly IAtividadesService _atividadesService = atividadesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Atividades", "GetAll", $"max = {max}", uri);
        var result = await _atividadesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAtividades filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Atividades: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _atividadesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Atividades: GetById called with id = {0}, {1}", id, uri);
        var result = await _atividadesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Atividades found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAtividades? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Atividades: GetListN called, max {max}, {filtro} uri");
        var result = await _atividadesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Atividades regAtividades, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Atividades", "AddAndUpdate", regAtividades, uri);
        try
        {
            var result = await _atividadesService.AddAndUpdate(regAtividades, uri);
            if (result == null)
            {
                _logger.Warn("Atividades: AddAndUpdate failed to add or update Atividades, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Atividades: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Atividades: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _atividadesService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Atividades found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Atividades: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Atividades regAtividades, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _atividadesService.Validation(regAtividades, uri);
            if (result == null)
            {
                _logger.Warn("Atividades: Validation failed to add or update Atividades, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Atividades: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}