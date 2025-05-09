﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EscritoriosController(IEscritoriosService escritoriosService) : ControllerBase
{
    private readonly IEscritoriosService _escritoriosService = escritoriosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Escritorios", "GetAll", $"max = {max}", uri);
        var result = await _escritoriosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEscritorios filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Escritorios: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _escritoriosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Escritorios: GetById called with id = {0}, {1}", id, uri);
        var result = await _escritoriosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Escritorios found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Escritorios: GetByName called with name = {0}, {1}", name, uri);
        var result = await _escritoriosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Escritorios found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterEscritorios? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Escritorios: GetListN called, max {max}, {filtro} uri");
        var result = await _escritoriosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Escritorios regEscritorios, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Escritorios", "AddAndUpdate", regEscritorios, uri);
        var result = await _escritoriosService.AddAndUpdate(regEscritorios, uri);
        if (result == null)
        {
            _logger.Warn("Escritorios: AddAndUpdate failed to add or update Escritorios, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Escritorios: Delete called with id = {0}, {2}", id, uri);
        var result = await _escritoriosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Escritorios found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}