﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProcessosController(IProcessosService processosService) : ControllerBase
{
    private readonly IProcessosService _processosService = processosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Processos", "GetAll", $"max = {max}", uri);
        var result = await _processosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProcessos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Processos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _processosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Processos: GetById called with id = {0}, {1}", id, uri);
        var result = await _processosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Processos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Processos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _processosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Processos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Processos: GetListN called, max {max}, {filtro} uri");
        var result = await _processosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Processos regProcessos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Processos", "AddAndUpdate", regProcessos, uri);
        var result = await _processosService.AddAndUpdate(regProcessos, uri);
        if (result == null)
        {
            _logger.Warn("Processos: AddAndUpdate failed to add or update Processos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Processos: Delete called with id = {0}, {2}", id, uri);
        var result = await _processosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Processos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}