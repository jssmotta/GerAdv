﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GruposEmpresasCliController(IGruposEmpresasCliService gruposempresascliService) : ControllerBase
{
    private readonly IGruposEmpresasCliService _gruposempresascliService = gruposempresascliService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GruposEmpresasCli", "GetAll", $"max = {max}", uri);
        var result = await _gruposempresascliService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGruposEmpresasCli filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresasCli: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gruposempresascliService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("GruposEmpresasCli: GetById called with id = {0}, {1}", id, uri);
        var result = await _gruposempresascliService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GruposEmpresasCli found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GruposEmpresasCli regGruposEmpresasCli, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GruposEmpresasCli", "AddAndUpdate", regGruposEmpresasCli, uri);
        var result = await _gruposempresascliService.AddAndUpdate(regGruposEmpresasCli, uri);
        if (result == null)
        {
            _logger.Warn("GruposEmpresasCli: AddAndUpdate failed to add or update GruposEmpresasCli, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresasCli: Delete called with id = {0}, {2}", id, uri);
        var result = await _gruposempresascliService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No GruposEmpresasCli found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}