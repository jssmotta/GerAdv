﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TipoStatusBiuController(ITipoStatusBiuService tipostatusbiuService) : ControllerBase
{
    private readonly ITipoStatusBiuService _tipostatusbiuService = tipostatusbiuService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoStatusBiu", "GetAll", $"max = {max}", uri);
        var result = await _tipostatusbiuService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTipoStatusBiu filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoStatusBiu: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _tipostatusbiuService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("TipoStatusBiu: GetById called with id = {0}, {1}", id, uri);
        var result = await _tipostatusbiuService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No TipoStatusBiu found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoStatusBiu: GetByName called with name = {0}, {1}", name, uri);
        var result = await _tipostatusbiuService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No TipoStatusBiu found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterTipoStatusBiu? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"TipoStatusBiu: GetListN called, max {max}, {filtro} uri");
        var result = await _tipostatusbiuService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.TipoStatusBiu regTipoStatusBiu, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("TipoStatusBiu", "AddAndUpdate", regTipoStatusBiu, uri);
        var result = await _tipostatusbiuService.AddAndUpdate(regTipoStatusBiu, uri);
        if (result == null)
        {
            _logger.Warn("TipoStatusBiu: AddAndUpdate failed to add or update TipoStatusBiu, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("TipoStatusBiu: Delete called with id = {0}, {2}", id, uri);
        var result = await _tipostatusbiuService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No TipoStatusBiu found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}