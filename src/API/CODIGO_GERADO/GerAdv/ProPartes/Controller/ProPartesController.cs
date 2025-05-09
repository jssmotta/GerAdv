﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProPartesController(IProPartesService propartesService) : ControllerBase
{
    private readonly IProPartesService _propartesService = propartesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProPartes", "GetAll", $"max = {max}", uri);
        var result = await _propartesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProPartes filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProPartes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _propartesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProPartes: GetById called with id = {0}, {1}", id, uri);
        var result = await _propartesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProPartes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProPartes regProPartes, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProPartes", "AddAndUpdate", regProPartes, uri);
        var result = await _propartesService.AddAndUpdate(regProPartes, uri);
        if (result == null)
        {
            _logger.Warn("ProPartes: AddAndUpdate failed to add or update ProPartes, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProPartes: Delete called with id = {0}, {2}", id, uri);
        var result = await _propartesService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProPartes found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}