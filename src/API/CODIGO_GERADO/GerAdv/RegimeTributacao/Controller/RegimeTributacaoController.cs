#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class RegimeTributacaoController(IRegimeTributacaoService regimetributacaoService) : ControllerBase
{
    private readonly IRegimeTributacaoService _regimetributacaoService = regimetributacaoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("RegimeTributacao", "GetAll", $"max = {max}", uri);
        var result = await _regimetributacaoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterRegimeTributacao filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("RegimeTributacao: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _regimetributacaoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("RegimeTributacao: GetById called with id = {0}, {1}", id, uri);
        var result = await _regimetributacaoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No RegimeTributacao found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterRegimeTributacao? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"RegimeTributacao: GetListN called, max {max}, {filtro} uri");
        var result = await _regimetributacaoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.RegimeTributacao regRegimeTributacao, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("RegimeTributacao", "AddAndUpdate", regRegimeTributacao, uri);
        try
        {
            var result = await _regimetributacaoService.AddAndUpdate(regRegimeTributacao, uri);
            if (result == null)
            {
                _logger.Warn("RegimeTributacao: AddAndUpdate failed to add or update RegimeTributacao, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "RegimeTributacao: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("RegimeTributacao: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _regimetributacaoService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No RegimeTributacao found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "RegimeTributacao: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.RegimeTributacao regRegimeTributacao, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _regimetributacaoService.Validation(regRegimeTributacao, uri);
            if (result == null)
            {
                _logger.Warn("RegimeTributacao: Validation failed to add or update RegimeTributacao, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "RegimeTributacao: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}