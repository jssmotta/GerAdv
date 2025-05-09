﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TipoRecursoController(ITipoRecursoService tiporecursoService) : ControllerBase
{
    private readonly ITipoRecursoService _tiporecursoService = tiporecursoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoRecurso", "GetAll", $"max = {max}", uri);
        var result = await _tiporecursoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTipoRecurso filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoRecurso: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _tiporecursoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("TipoRecurso: GetById called with id = {0}, {1}", id, uri);
        var result = await _tiporecursoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No TipoRecurso found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoRecurso: GetByName called with name = {0}, {1}", name, uri);
        var result = await _tiporecursoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No TipoRecurso found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoRecurso? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"TipoRecurso: GetListN called, max {max}, {filtro} uri");
        var result = await _tiporecursoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.TipoRecurso regTipoRecurso, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoRecurso", "AddAndUpdate", regTipoRecurso, uri);
        var result = await _tiporecursoService.AddAndUpdate(regTipoRecurso, uri);
        if (result == null)
        {
            _logger.Warn("TipoRecurso: AddAndUpdate failed to add or update TipoRecurso, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoRecurso: Delete called with id = {0}, {2}", id, uri);
        var result = await _tiporecursoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No TipoRecurso found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}