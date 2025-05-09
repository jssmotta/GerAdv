﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProCDAController(IProCDAService procdaService) : ControllerBase
{
    private readonly IProCDAService _procdaService = procdaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProCDA", "GetAll", $"max = {max}", uri);
        var result = await _procdaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProCDA filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProCDA: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _procdaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProCDA: GetById called with id = {0}, {1}", id, uri);
        var result = await _procdaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProCDA found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ProCDA: GetByName called with name = {0}, {1}", name, uri);
        var result = await _procdaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ProCDA found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProCDA? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ProCDA: GetListN called, max {max}, {filtro} uri");
        var result = await _procdaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProCDA regProCDA, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProCDA", "AddAndUpdate", regProCDA, uri);
        var result = await _procdaService.AddAndUpdate(regProCDA, uri);
        if (result == null)
        {
            _logger.Warn("ProCDA: AddAndUpdate failed to add or update ProCDA, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProCDA: Delete called with id = {0}, {2}", id, uri);
        var result = await _procdaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProCDA found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}