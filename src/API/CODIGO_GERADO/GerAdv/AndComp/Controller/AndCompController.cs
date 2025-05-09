﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AndCompController(IAndCompService andcompService) : ControllerBase
{
    private readonly IAndCompService _andcompService = andcompService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AndComp", "GetAll", $"max = {max}", uri);
        var result = await _andcompService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAndComp filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AndComp: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _andcompService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AndComp: GetById called with id = {0}, {1}", id, uri);
        var result = await _andcompService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AndComp found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AndComp regAndComp, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AndComp", "AddAndUpdate", regAndComp, uri);
        var result = await _andcompService.AddAndUpdate(regAndComp, uri);
        if (result == null)
        {
            _logger.Warn("AndComp: AddAndUpdate failed to add or update AndComp, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AndComp: Delete called with id = {0}, {2}", id, uri);
        var result = await _andcompService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AndComp found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}