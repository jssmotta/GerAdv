﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class StatusInstanciaController(IStatusInstanciaService statusinstanciaService) : ControllerBase
{
    private readonly IStatusInstanciaService _statusinstanciaService = statusinstanciaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusInstancia", "GetAll", $"max = {max}", uri);
        var result = await _statusinstanciaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterStatusInstancia filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusInstancia: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _statusinstanciaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("StatusInstancia: GetById called with id = {0}, {1}", id, uri);
        var result = await _statusinstanciaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No StatusInstancia found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusInstancia: GetByName called with name = {0}, {1}", name, uri);
        var result = await _statusinstanciaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No StatusInstancia found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterStatusInstancia? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"StatusInstancia: GetListN called, max {max}, {filtro} uri");
        var result = await _statusinstanciaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.StatusInstancia regStatusInstancia, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("StatusInstancia", "AddAndUpdate", regStatusInstancia, uri);
        var result = await _statusinstanciaService.AddAndUpdate(regStatusInstancia, uri);
        if (result == null)
        {
            _logger.Warn("StatusInstancia: AddAndUpdate failed to add or update StatusInstancia, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("StatusInstancia: Delete called with id = {0}, {2}", id, uri);
        var result = await _statusinstanciaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No StatusInstancia found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}