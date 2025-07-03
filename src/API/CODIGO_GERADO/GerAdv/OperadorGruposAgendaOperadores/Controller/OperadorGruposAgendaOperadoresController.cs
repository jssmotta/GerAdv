#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadorGruposAgendaOperadoresController(IOperadorGruposAgendaOperadoresService operadorgruposagendaoperadoresService) : ControllerBase
{
    private readonly IOperadorGruposAgendaOperadoresService _operadorgruposagendaoperadoresService = operadorgruposagendaoperadoresService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("OperadorGruposAgendaOperadores", "GetAll", $"max = {max}", uri);
        var result = await _operadorgruposagendaoperadoresService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOperadorGruposAgendaOperadores filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("OperadorGruposAgendaOperadores: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _operadorgruposagendaoperadoresService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("OperadorGruposAgendaOperadores: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadorgruposagendaoperadoresService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No OperadorGruposAgendaOperadores found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("OperadorGruposAgendaOperadores", "AddAndUpdate", regOperadorGruposAgendaOperadores, uri);
        try
        {
            var result = await _operadorgruposagendaoperadoresService.AddAndUpdate(regOperadorGruposAgendaOperadores, uri);
            if (result == null)
            {
                _logger.Warn("OperadorGruposAgendaOperadores: AddAndUpdate failed to add or update OperadorGruposAgendaOperadores, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "OperadorGruposAgendaOperadores: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("OperadorGruposAgendaOperadores: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _operadorgruposagendaoperadoresService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No OperadorGruposAgendaOperadores found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "OperadorGruposAgendaOperadores: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.OperadorGruposAgendaOperadores regOperadorGruposAgendaOperadores, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _operadorgruposagendaoperadoresService.Validation(regOperadorGruposAgendaOperadores, uri);
            if (result == null)
            {
                _logger.Warn("OperadorGruposAgendaOperadores: Validation failed to add or update OperadorGruposAgendaOperadores, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "OperadorGruposAgendaOperadores: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}