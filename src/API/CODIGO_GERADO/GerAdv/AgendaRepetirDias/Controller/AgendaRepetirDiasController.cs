#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaRepetirDiasController(IAgendaRepetirDiasService agendarepetirdiasService) : ControllerBase
{
    private readonly IAgendaRepetirDiasService _agendarepetirdiasService = agendarepetirdiasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("AgendaRepetirDias", "GetAll", $"max = {max}", uri);
        var result = await _agendarepetirdiasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgendaRepetirDias filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("AgendaRepetirDias: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendarepetirdiasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("AgendaRepetirDias: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendarepetirdiasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaRepetirDias found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AgendaRepetirDias regAgendaRepetirDias, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("AgendaRepetirDias", "AddAndUpdate", regAgendaRepetirDias, uri);
        try
        {
            var result = await _agendarepetirdiasService.AddAndUpdate(regAgendaRepetirDias, uri);
            if (result == null)
            {
                _logger.Warn("AgendaRepetirDias: AddAndUpdate failed to add or update AgendaRepetirDias, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "AgendaRepetirDias: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("AgendaRepetirDias: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _agendarepetirdiasService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No AgendaRepetirDias found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "AgendaRepetirDias: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.AgendaRepetirDias regAgendaRepetirDias, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _agendarepetirdiasService.Validation(regAgendaRepetirDias, uri);
            if (result == null)
            {
                _logger.Warn("AgendaRepetirDias: Validation failed to add or update AgendaRepetirDias, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "AgendaRepetirDias: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}