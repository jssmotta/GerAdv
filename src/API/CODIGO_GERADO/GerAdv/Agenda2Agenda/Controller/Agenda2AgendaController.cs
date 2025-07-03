#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class Agenda2AgendaController(IAgenda2AgendaService agenda2agendaService) : ControllerBase
{
    private readonly IAgenda2AgendaService _agenda2agendaService = agenda2agendaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Agenda2Agenda", "GetAll", $"max = {max}", uri);
        var result = await _agenda2agendaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgenda2Agenda filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Agenda2Agenda: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agenda2agendaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Agenda2Agenda: GetById called with id = {0}, {1}", id, uri);
        var result = await _agenda2agendaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Agenda2Agenda found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Agenda2Agenda regAgenda2Agenda, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Agenda2Agenda", "AddAndUpdate", regAgenda2Agenda, uri);
        try
        {
            var result = await _agenda2agendaService.AddAndUpdate(regAgenda2Agenda, uri);
            if (result == null)
            {
                _logger.Warn("Agenda2Agenda: AddAndUpdate failed to add or update Agenda2Agenda, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Agenda2Agenda: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Agenda2Agenda: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _agenda2agendaService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Agenda2Agenda found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Agenda2Agenda: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Agenda2Agenda regAgenda2Agenda, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _agenda2agendaService.Validation(regAgenda2Agenda, uri);
            if (result == null)
            {
                _logger.Warn("Agenda2Agenda: Validation failed to add or update Agenda2Agenda, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Agenda2Agenda: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}