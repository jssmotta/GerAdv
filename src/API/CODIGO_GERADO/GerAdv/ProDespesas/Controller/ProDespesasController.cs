﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProDespesasController(IProDespesasService prodespesasService) : ControllerBase
{
    private readonly IProDespesasService _prodespesasService = prodespesasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProDespesas", "GetAll", $"max = {max}", uri);
        var result = await _prodespesasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProDespesas filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProDespesas: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _prodespesasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProDespesas: GetById called with id = {0}, {1}", id, uri);
        var result = await _prodespesasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProDespesas found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProDespesas regProDespesas, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProDespesas", "AddAndUpdate", regProDespesas, uri);
        var result = await _prodespesasService.AddAndUpdate(regProDespesas, uri);
        if (result == null)
        {
            _logger.Warn("ProDespesas: AddAndUpdate failed to add or update ProDespesas, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProDespesas: Delete called with id = {0}, {2}", id, uri);
        var result = await _prodespesasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProDespesas found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}