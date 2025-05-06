#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EventoPrazoAgendaController(IEventoPrazoAgendaService eventoprazoagendaService) : ControllerBase
{
    private readonly IEventoPrazoAgendaService _eventoprazoagendaService = eventoprazoagendaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EventoPrazoAgenda", "GetAll", $"max = {max}", uri);
        var result = await _eventoprazoagendaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEventoPrazoAgenda filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("EventoPrazoAgenda: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _eventoprazoagendaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("EventoPrazoAgenda: GetById called with id = {0}, {1}", id, uri);
        var result = await _eventoprazoagendaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No EventoPrazoAgenda found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("EventoPrazoAgenda: GetByName called with name = {0}, {1}", name, uri);
        var result = await _eventoprazoagendaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No EventoPrazoAgenda found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterEventoPrazoAgenda? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"EventoPrazoAgenda: GetListN called, max {max}, {filtro} uri");
        var result = await _eventoprazoagendaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.EventoPrazoAgenda regEventoPrazoAgenda, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EventoPrazoAgenda", "AddAndUpdate", regEventoPrazoAgenda, uri);
        var result = await _eventoprazoagendaService.AddAndUpdate(regEventoPrazoAgenda, uri);
        if (result == null)
        {
            _logger.Warn("EventoPrazoAgenda: AddAndUpdate failed to add or update EventoPrazoAgenda, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("EventoPrazoAgenda: Delete called with id = {0}, {2}", id, uri);
        var result = await _eventoprazoagendaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No EventoPrazoAgenda found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}