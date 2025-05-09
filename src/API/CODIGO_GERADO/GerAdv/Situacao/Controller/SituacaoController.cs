﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class SituacaoController(ISituacaoService situacaoService) : ControllerBase
{
    private readonly ISituacaoService _situacaoService = situacaoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Situacao", "GetAll", $"max = {max}", uri);
        var result = await _situacaoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterSituacao filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Situacao: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _situacaoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Situacao: GetById called with id = {0}, {1}", id, uri);
        var result = await _situacaoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Situacao found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Situacao regSituacao, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Situacao", "AddAndUpdate", regSituacao, uri);
        var result = await _situacaoService.AddAndUpdate(regSituacao, uri);
        if (result == null)
        {
            _logger.Warn("Situacao: AddAndUpdate failed to add or update Situacao, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Situacao: Delete called with id = {0}, {2}", id, uri);
        var result = await _situacaoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Situacao found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}