﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AnexamentoRegistrosController(IAnexamentoRegistrosService anexamentoregistrosService) : ControllerBase
{
    private readonly IAnexamentoRegistrosService _anexamentoregistrosService = anexamentoregistrosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AnexamentoRegistros", "GetAll", $"max = {max}", uri);
        var result = await _anexamentoregistrosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAnexamentoRegistros filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("AnexamentoRegistros: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _anexamentoregistrosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("AnexamentoRegistros: GetById called with id = {0}, {1}", id, uri);
        var result = await _anexamentoregistrosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AnexamentoRegistros found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AnexamentoRegistros regAnexamentoRegistros, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("AnexamentoRegistros", "AddAndUpdate", regAnexamentoRegistros, uri);
        var result = await _anexamentoregistrosService.AddAndUpdate(regAnexamentoRegistros, uri);
        if (result == null)
        {
            _logger.Warn("AnexamentoRegistros: AddAndUpdate failed to add or update AnexamentoRegistros, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("AnexamentoRegistros: Delete called with id = {0}, {2}", id, uri);
        var result = await _anexamentoregistrosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No AnexamentoRegistros found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}