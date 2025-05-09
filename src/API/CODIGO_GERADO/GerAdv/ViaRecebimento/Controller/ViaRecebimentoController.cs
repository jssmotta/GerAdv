﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ViaRecebimentoController(IViaRecebimentoService viarecebimentoService) : ControllerBase
{
    private readonly IViaRecebimentoService _viarecebimentoService = viarecebimentoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ViaRecebimento", "GetAll", $"max = {max}", uri);
        var result = await _viarecebimentoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterViaRecebimento filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ViaRecebimento: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _viarecebimentoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ViaRecebimento: GetById called with id = {0}, {1}", id, uri);
        var result = await _viarecebimentoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ViaRecebimento found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ViaRecebimento: GetByName called with name = {0}, {1}", name, uri);
        var result = await _viarecebimentoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ViaRecebimento found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterViaRecebimento? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ViaRecebimento: GetListN called, max {max}, {filtro} uri");
        var result = await _viarecebimentoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ViaRecebimento regViaRecebimento, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ViaRecebimento", "AddAndUpdate", regViaRecebimento, uri);
        var result = await _viarecebimentoService.AddAndUpdate(regViaRecebimento, uri);
        if (result == null)
        {
            _logger.Warn("ViaRecebimento: AddAndUpdate failed to add or update ViaRecebimento, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ViaRecebimento: Delete called with id = {0}, {2}", id, uri);
        var result = await _viarecebimentoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ViaRecebimento found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}