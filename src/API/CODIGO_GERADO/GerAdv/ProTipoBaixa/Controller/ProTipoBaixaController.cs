#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProTipoBaixaController(IProTipoBaixaService protipobaixaService) : ControllerBase
{
    private readonly IProTipoBaixaService _protipobaixaService = protipobaixaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProTipoBaixa", "GetAll", $"max = {max}", uri);
        var result = await _protipobaixaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProTipoBaixa filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProTipoBaixa: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _protipobaixaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("ProTipoBaixa: GetById called with id = {0}, {1}", id, uri);
        var result = await _protipobaixaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProTipoBaixa found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProTipoBaixa? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"ProTipoBaixa: GetListN called, max {max}, {filtro} uri");
        var result = await _protipobaixaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProTipoBaixa regProTipoBaixa, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("ProTipoBaixa", "AddAndUpdate", regProTipoBaixa, uri);
        try
        {
            var result = await _protipobaixaService.AddAndUpdate(regProTipoBaixa, uri);
            if (result == null)
            {
                _logger.Warn("ProTipoBaixa: AddAndUpdate failed to add or update ProTipoBaixa, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProTipoBaixa: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("ProTipoBaixa: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _protipobaixaService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No ProTipoBaixa found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProTipoBaixa: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.ProTipoBaixa regProTipoBaixa, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _protipobaixaService.Validation(regProTipoBaixa, uri);
            if (result == null)
            {
                _logger.Warn("ProTipoBaixa: Validation failed to add or update ProTipoBaixa, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ProTipoBaixa: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}