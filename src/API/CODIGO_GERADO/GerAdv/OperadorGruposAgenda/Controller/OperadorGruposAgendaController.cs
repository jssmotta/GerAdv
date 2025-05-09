﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadorGruposAgendaController(IOperadorGruposAgendaService operadorgruposagendaService) : ControllerBase
{
    private readonly IOperadorGruposAgendaService _operadorgruposagendaService = operadorgruposagendaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorGruposAgenda", "GetAll", $"max = {max}", uri);
        var result = await _operadorgruposagendaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOperadorGruposAgenda filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGruposAgenda: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _operadorgruposagendaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("OperadorGruposAgenda: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadorgruposagendaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No OperadorGruposAgenda found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGruposAgenda: GetByName called with name = {0}, {1}", name, uri);
        var result = await _operadorgruposagendaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No OperadorGruposAgenda found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorGruposAgenda? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"OperadorGruposAgenda: GetListN called, max {max}, {filtro} uri");
        var result = await _operadorgruposagendaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.OperadorGruposAgenda regOperadorGruposAgenda, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorGruposAgenda", "AddAndUpdate", regOperadorGruposAgenda, uri);
        var result = await _operadorgruposagendaService.AddAndUpdate(regOperadorGruposAgenda, uri);
        if (result == null)
        {
            _logger.Warn("OperadorGruposAgenda: AddAndUpdate failed to add or update OperadorGruposAgenda, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorGruposAgenda: Delete called with id = {0}, {2}", id, uri);
        var result = await _operadorgruposagendaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No OperadorGruposAgenda found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}