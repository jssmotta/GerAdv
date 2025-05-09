﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaStatusController(IAgendaStatusService agendastatusService) : ControllerBase
{
    private readonly IAgendaStatusService _agendastatusService = agendastatusService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaStatus", "GetAll", $"max = {max}", uri);
        var result = await _agendastatusService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgendaStatus filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaStatus: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendastatusService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AgendaStatus: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendastatusService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaStatus found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AgendaStatus regAgendaStatus, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaStatus", "AddAndUpdate", regAgendaStatus, uri);
        var result = await _agendastatusService.AddAndUpdate(regAgendaStatus, uri);
        if (result == null)
        {
            _logger.Warn("AgendaStatus: AddAndUpdate failed to add or update AgendaStatus, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaStatus: Delete called with id = {0}, {2}", id, uri);
        var result = await _agendastatusService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AgendaStatus found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}