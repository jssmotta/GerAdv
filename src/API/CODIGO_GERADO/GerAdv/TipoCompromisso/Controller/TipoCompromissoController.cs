﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TipoCompromissoController(ITipoCompromissoService tipocompromissoService) : ControllerBase
{
    private readonly ITipoCompromissoService _tipocompromissoService = tipocompromissoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoCompromisso", "GetAll", $"max = {max}", uri);
        var result = await _tipocompromissoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTipoCompromisso filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoCompromisso: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _tipocompromissoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("TipoCompromisso: GetById called with id = {0}, {1}", id, uri);
        var result = await _tipocompromissoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No TipoCompromisso found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoCompromisso: GetByName called with name = {0}, {1}", name, uri);
        var result = await _tipocompromissoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No TipoCompromisso found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoCompromisso? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"TipoCompromisso: GetListN called, max {max}, {filtro} uri");
        var result = await _tipocompromissoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.TipoCompromisso regTipoCompromisso, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoCompromisso", "AddAndUpdate", regTipoCompromisso, uri);
        var result = await _tipocompromissoService.AddAndUpdate(regTipoCompromisso, uri);
        if (result == null)
        {
            _logger.Warn("TipoCompromisso: AddAndUpdate failed to add or update TipoCompromisso, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoCompromisso: Delete called with id = {0}, {2}", id, uri);
        var result = await _tipocompromissoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No TipoCompromisso found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}