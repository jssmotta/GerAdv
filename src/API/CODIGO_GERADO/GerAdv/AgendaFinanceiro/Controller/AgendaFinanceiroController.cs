﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AgendaFinanceiroController(IAgendaFinanceiroService agendafinanceiroService) : ControllerBase
{
    private readonly IAgendaFinanceiroService _agendafinanceiroService = agendafinanceiroService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaFinanceiro", "GetAll", $"max = {max}", uri);
        var result = await _agendafinanceiroService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAgendaFinanceiro filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaFinanceiro: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _agendafinanceiroService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AgendaFinanceiro: GetById called with id = {0}, {1}", id, uri);
        var result = await _agendafinanceiroService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AgendaFinanceiro found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AgendaFinanceiro regAgendaFinanceiro, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AgendaFinanceiro", "AddAndUpdate", regAgendaFinanceiro, uri);
        var result = await _agendafinanceiroService.AddAndUpdate(regAgendaFinanceiro, uri);
        if (result == null)
        {
            _logger.Warn("AgendaFinanceiro: AddAndUpdate failed to add or update AgendaFinanceiro, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AgendaFinanceiro: Delete called with id = {0}, {2}", id, uri);
        var result = await _agendafinanceiroService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AgendaFinanceiro found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}