﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PenhoraController(IPenhoraService penhoraService) : ControllerBase
{
    private readonly IPenhoraService _penhoraService = penhoraService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Penhora", "GetAll", $"max = {max}", uri);
        var result = await _penhoraService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPenhora filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Penhora: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _penhoraService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Penhora: GetById called with id = {0}, {1}", id, uri);
        var result = await _penhoraService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Penhora found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Penhora: GetByName called with name = {0}, {1}", name, uri);
        var result = await _penhoraService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Penhora found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterPenhora? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Penhora: GetListN called, max {max}, {filtro} uri");
        var result = await _penhoraService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Penhora regPenhora, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Penhora", "AddAndUpdate", regPenhora, uri);
        var result = await _penhoraService.AddAndUpdate(regPenhora, uri);
        if (result == null)
        {
            _logger.Warn("Penhora: AddAndUpdate failed to add or update Penhora, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Penhora: Delete called with id = {0}, {2}", id, uri);
        var result = await _penhoraService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Penhora found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}