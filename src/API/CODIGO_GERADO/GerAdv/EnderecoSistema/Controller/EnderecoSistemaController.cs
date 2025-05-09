﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EnderecoSistemaController(IEnderecoSistemaService enderecosistemaService) : ControllerBase
{
    private readonly IEnderecoSistemaService _enderecosistemaService = enderecosistemaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EnderecoSistema", "GetAll", $"max = {max}", uri);
        var result = await _enderecosistemaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEnderecoSistema filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("EnderecoSistema: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _enderecosistemaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("EnderecoSistema: GetById called with id = {0}, {1}", id, uri);
        var result = await _enderecosistemaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No EnderecoSistema found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.EnderecoSistema regEnderecoSistema, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EnderecoSistema", "AddAndUpdate", regEnderecoSistema, uri);
        var result = await _enderecosistemaService.AddAndUpdate(regEnderecoSistema, uri);
        if (result == null)
        {
            _logger.Warn("EnderecoSistema: AddAndUpdate failed to add or update EnderecoSistema, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("EnderecoSistema: Delete called with id = {0}, {2}", id, uri);
        var result = await _enderecosistemaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No EnderecoSistema found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}