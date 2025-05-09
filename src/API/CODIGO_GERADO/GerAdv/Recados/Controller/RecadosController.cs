﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class RecadosController(IRecadosService recadosService) : ControllerBase
{
    private readonly IRecadosService _recadosService = recadosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Recados", "GetAll", $"max = {max}", uri);
        var result = await _recadosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterRecados filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Recados: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _recadosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Recados: GetById called with id = {0}, {1}", id, uri);
        var result = await _recadosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Recados found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Recados regRecados, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Recados", "AddAndUpdate", regRecados, uri);
        var result = await _recadosService.AddAndUpdate(regRecados, uri);
        if (result == null)
        {
            _logger.Warn("Recados: AddAndUpdate failed to add or update Recados, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Recados: Delete called with id = {0}, {2}", id, uri);
        var result = await _recadosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Recados found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}