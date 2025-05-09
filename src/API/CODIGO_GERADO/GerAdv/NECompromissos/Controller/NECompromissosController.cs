﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class NECompromissosController(INECompromissosService necompromissosService) : ControllerBase
{
    private readonly INECompromissosService _necompromissosService = necompromissosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("NECompromissos", "GetAll", $"max = {max}", uri);
        var result = await _necompromissosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterNECompromissos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("NECompromissos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _necompromissosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("NECompromissos: GetById called with id = {0}, {1}", id, uri);
        var result = await _necompromissosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No NECompromissos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.NECompromissos regNECompromissos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("NECompromissos", "AddAndUpdate", regNECompromissos, uri);
        var result = await _necompromissosService.AddAndUpdate(regNECompromissos, uri);
        if (result == null)
        {
            _logger.Warn("NECompromissos: AddAndUpdate failed to add or update NECompromissos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("NECompromissos: Delete called with id = {0}, {2}", id, uri);
        var result = await _necompromissosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No NECompromissos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}