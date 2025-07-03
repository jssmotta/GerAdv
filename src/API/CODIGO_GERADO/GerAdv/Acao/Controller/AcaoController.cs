#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AcaoController(IAcaoService acaoService) : ControllerBase
{
    private readonly IAcaoService _acaoService = acaoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Acao", "GetAll", $"max = {max}", uri);
        var result = await _acaoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAcao filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Acao: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _acaoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Acao: GetById called with id = {0}, {1}", id, uri);
        var result = await _acaoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Acao found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAcao? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Acao: GetListN called, max {max}, {filtro} uri");
        var result = await _acaoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Acao regAcao, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Acao", "AddAndUpdate", regAcao, uri);
        try
        {
            var result = await _acaoService.AddAndUpdate(regAcao, uri);
            if (result == null)
            {
                _logger.Warn("Acao: AddAndUpdate failed to add or update Acao, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Acao: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Acao: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _acaoService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Acao found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Acao: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Acao regAcao, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _acaoService.Validation(regAcao, uri);
            if (result == null)
            {
                _logger.Warn("Acao: Validation failed to add or update Acao, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Acao: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}