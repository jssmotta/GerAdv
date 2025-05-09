﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class PoderJudiciarioAssociadoController(IPoderJudiciarioAssociadoService poderjudiciarioassociadoService) : ControllerBase
{
    private readonly IPoderJudiciarioAssociadoService _poderjudiciarioassociadoService = poderjudiciarioassociadoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PoderJudiciarioAssociado", "GetAll", $"max = {max}", uri);
        var result = await _poderjudiciarioassociadoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterPoderJudiciarioAssociado filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("PoderJudiciarioAssociado: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _poderjudiciarioassociadoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("PoderJudiciarioAssociado: GetById called with id = {0}, {1}", id, uri);
        var result = await _poderjudiciarioassociadoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No PoderJudiciarioAssociado found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("PoderJudiciarioAssociado", "AddAndUpdate", regPoderJudiciarioAssociado, uri);
        var result = await _poderjudiciarioassociadoService.AddAndUpdate(regPoderJudiciarioAssociado, uri);
        if (result == null)
        {
            _logger.Warn("PoderJudiciarioAssociado: AddAndUpdate failed to add or update PoderJudiciarioAssociado, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("PoderJudiciarioAssociado: Delete called with id = {0}, {2}", id, uri);
        var result = await _poderjudiciarioassociadoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No PoderJudiciarioAssociado found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}