﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class UltimosProcessosController(IUltimosProcessosService ultimosprocessosService) : ControllerBase
{
    private readonly IUltimosProcessosService _ultimosprocessosService = ultimosprocessosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("UltimosProcessos", "GetAll", $"max = {max}", uri);
        var result = await _ultimosprocessosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterUltimosProcessos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("UltimosProcessos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _ultimosprocessosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("UltimosProcessos: GetById called with id = {0}, {1}", id, uri);
        var result = await _ultimosprocessosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No UltimosProcessos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.UltimosProcessos regUltimosProcessos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("UltimosProcessos", "AddAndUpdate", regUltimosProcessos, uri);
        var result = await _ultimosprocessosService.AddAndUpdate(regUltimosProcessos, uri);
        if (result == null)
        {
            _logger.Warn("UltimosProcessos: AddAndUpdate failed to add or update UltimosProcessos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("UltimosProcessos: Delete called with id = {0}, {2}", id, uri);
        var result = await _ultimosprocessosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No UltimosProcessos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}