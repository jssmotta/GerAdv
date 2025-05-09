﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProcessOutputSourcesController(IProcessOutputSourcesService processoutputsourcesService) : ControllerBase
{
    private readonly IProcessOutputSourcesService _processoutputsourcesService = processoutputsourcesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProcessOutputSources", "GetAll", $"max = {max}", uri);
        var result = await _processoutputsourcesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProcessOutputSources filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutputSources: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _processoutputsourcesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProcessOutputSources: GetById called with id = {0}, {1}", id, uri);
        var result = await _processoutputsourcesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProcessOutputSources found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutputSources: GetByName called with name = {0}, {1}", name, uri);
        var result = await _processoutputsourcesService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ProcessOutputSources found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutputSources? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ProcessOutputSources: GetListN called, max {max}, {filtro} uri");
        var result = await _processoutputsourcesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProcessOutputSources regProcessOutputSources, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProcessOutputSources", "AddAndUpdate", regProcessOutputSources, uri);
        var result = await _processoutputsourcesService.AddAndUpdate(regProcessOutputSources, uri);
        if (result == null)
        {
            _logger.Warn("ProcessOutputSources: AddAndUpdate failed to add or update ProcessOutputSources, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutputSources: Delete called with id = {0}, {2}", id, uri);
        var result = await _processoutputsourcesService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProcessOutputSources found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}