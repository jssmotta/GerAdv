﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PosicaoOutrasPartesController(IPosicaoOutrasPartesService posicaooutraspartesService) : ControllerBase
{
    private readonly IPosicaoOutrasPartesService _posicaooutraspartesService = posicaooutraspartesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PosicaoOutrasPartes", "GetAll", $"max = {max}", uri);
        var result = await _posicaooutraspartesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPosicaoOutrasPartes filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("PosicaoOutrasPartes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _posicaooutraspartesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("PosicaoOutrasPartes: GetById called with id = {0}, {1}", id, uri);
        var result = await _posicaooutraspartesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No PosicaoOutrasPartes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("PosicaoOutrasPartes: GetByName called with name = {0}, {1}", name, uri);
        var result = await _posicaooutraspartesService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No PosicaoOutrasPartes found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterPosicaoOutrasPartes? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"PosicaoOutrasPartes: GetListN called, max {max}, {filtro} uri");
        var result = await _posicaooutraspartesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.PosicaoOutrasPartes regPosicaoOutrasPartes, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PosicaoOutrasPartes", "AddAndUpdate", regPosicaoOutrasPartes, uri);
        var result = await _posicaooutraspartesService.AddAndUpdate(regPosicaoOutrasPartes, uri);
        if (result == null)
        {
            _logger.Warn("PosicaoOutrasPartes: AddAndUpdate failed to add or update PosicaoOutrasPartes, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("PosicaoOutrasPartes: Delete called with id = {0}, {2}", id, uri);
        var result = await _posicaooutraspartesService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No PosicaoOutrasPartes found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}