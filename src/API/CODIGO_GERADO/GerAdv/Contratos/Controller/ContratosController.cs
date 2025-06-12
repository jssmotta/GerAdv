#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ContratosController(IContratosService contratosService) : ControllerBase
{
    private readonly IContratosService _contratosService = contratosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Contratos", "GetAll", $"max = {max}", uri);
        var result = await _contratosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterContratos filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Contratos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _contratosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Contratos: GetById called with id = {0}, {1}", id, uri);
        var result = await _contratosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Contratos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Contratos regContratos, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Contratos", "AddAndUpdate", regContratos, uri);
        try
        {
            var result = await _contratosService.AddAndUpdate(regContratos, uri);
            if (result == null)
            {
                _logger.Warn("Contratos: AddAndUpdate failed to add or update Contratos, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Contratos: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Contratos: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _contratosService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Contratos found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Contratos: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }
}