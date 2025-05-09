﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TribunalController(ITribunalService tribunalService) : ControllerBase
{
    private readonly ITribunalService _tribunalService = tribunalService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Tribunal", "GetAll", $"max = {max}", uri);
        var result = await _tribunalService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTribunal filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Tribunal: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _tribunalService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Tribunal: GetById called with id = {0}, {1}", id, uri);
        var result = await _tribunalService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Tribunal found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Tribunal: GetByName called with name = {0}, {1}", name, uri);
        var result = await _tribunalService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Tribunal found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterTribunal? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Tribunal: GetListN called, max {max}, {filtro} uri");
        var result = await _tribunalService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Tribunal regTribunal, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Tribunal", "AddAndUpdate", regTribunal, uri);
        var result = await _tribunalService.AddAndUpdate(regTribunal, uri);
        if (result == null)
        {
            _logger.Warn("Tribunal: AddAndUpdate failed to add or update Tribunal, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Tribunal: Delete called with id = {0}, {2}", id, uri);
        var result = await _tribunalService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Tribunal found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}