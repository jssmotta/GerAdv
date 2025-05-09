﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GUTTipoController(IGUTTipoService guttipoService) : ControllerBase
{
    private readonly IGUTTipoService _guttipoService = guttipoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GUTTipo", "GetAll", $"max = {max}", uri);
        var result = await _guttipoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGUTTipo filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTTipo: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _guttipoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("GUTTipo: GetById called with id = {0}, {1}", id, uri);
        var result = await _guttipoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GUTTipo found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTTipo: GetByName called with name = {0}, {1}", name, uri);
        var result = await _guttipoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No GUTTipo found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTTipo? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"GUTTipo: GetListN called, max {max}, {filtro} uri");
        var result = await _guttipoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GUTTipo regGUTTipo, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GUTTipo", "AddAndUpdate", regGUTTipo, uri);
        var result = await _guttipoService.AddAndUpdate(regGUTTipo, uri);
        if (result == null)
        {
            _logger.Warn("GUTTipo: AddAndUpdate failed to add or update GUTTipo, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTTipo: Delete called with id = {0}, {2}", id, uri);
        var result = await _guttipoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No GUTTipo found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}