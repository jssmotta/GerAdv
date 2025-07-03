#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class FuncaoController(IFuncaoService funcaoService) : ControllerBase
{
    private readonly IFuncaoService _funcaoService = funcaoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Funcao", "GetAll", $"max = {max}", uri);
        var result = await _funcaoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterFuncao filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Funcao: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _funcaoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Funcao: GetById called with id = {0}, {1}", id, uri);
        var result = await _funcaoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Funcao found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterFuncao? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Funcao: GetListN called, max {max}, {filtro} uri");
        var result = await _funcaoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Funcao regFuncao, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Funcao", "AddAndUpdate", regFuncao, uri);
        try
        {
            var result = await _funcaoService.AddAndUpdate(regFuncao, uri);
            if (result == null)
            {
                _logger.Warn("Funcao: AddAndUpdate failed to add or update Funcao, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Funcao: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Funcao: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _funcaoService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Funcao found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Funcao: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Funcao regFuncao, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _funcaoService.Validation(regFuncao, uri);
            if (result == null)
            {
                _logger.Warn("Funcao: Validation failed to add or update Funcao, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Funcao: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}