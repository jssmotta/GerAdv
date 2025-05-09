﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AlertasController(IAlertasService alertasService) : ControllerBase
{
    private readonly IAlertasService _alertasService = alertasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Alertas", "GetAll", $"max = {max}", uri);
        var result = await _alertasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAlertas filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Alertas: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _alertasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Alertas: GetById called with id = {0}, {1}", id, uri);
        var result = await _alertasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Alertas found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Alertas: GetByName called with name = {0}, {1}", name, uri);
        var result = await _alertasService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Alertas found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAlertas? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Alertas: GetListN called, max {max}, {filtro} uri");
        var result = await _alertasService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Alertas regAlertas, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Alertas", "AddAndUpdate", regAlertas, uri);
        var result = await _alertasService.AddAndUpdate(regAlertas, uri);
        if (result == null)
        {
            _logger.Warn("Alertas: AddAndUpdate failed to add or update Alertas, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Alertas: Delete called with id = {0}, {2}", id, uri);
        var result = await _alertasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Alertas found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}