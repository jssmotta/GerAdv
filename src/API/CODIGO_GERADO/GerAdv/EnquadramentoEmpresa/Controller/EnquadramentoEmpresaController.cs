﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EnquadramentoEmpresaController(IEnquadramentoEmpresaService enquadramentoempresaService) : ControllerBase
{
    private readonly IEnquadramentoEmpresaService _enquadramentoempresaService = enquadramentoempresaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EnquadramentoEmpresa", "GetAll", $"max = {max}", uri);
        var result = await _enquadramentoempresaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEnquadramentoEmpresa filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("EnquadramentoEmpresa: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _enquadramentoempresaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("EnquadramentoEmpresa: GetById called with id = {0}, {1}", id, uri);
        var result = await _enquadramentoempresaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No EnquadramentoEmpresa found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("EnquadramentoEmpresa: GetByName called with name = {0}, {1}", name, uri);
        var result = await _enquadramentoempresaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No EnquadramentoEmpresa found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterEnquadramentoEmpresa? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"EnquadramentoEmpresa: GetListN called, max {max}, {filtro} uri");
        var result = await _enquadramentoempresaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.EnquadramentoEmpresa regEnquadramentoEmpresa, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EnquadramentoEmpresa", "AddAndUpdate", regEnquadramentoEmpresa, uri);
        var result = await _enquadramentoempresaService.AddAndUpdate(regEnquadramentoEmpresa, uri);
        if (result == null)
        {
            _logger.Warn("EnquadramentoEmpresa: AddAndUpdate failed to add or update EnquadramentoEmpresa, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("EnquadramentoEmpresa: Delete called with id = {0}, {2}", id, uri);
        var result = await _enquadramentoempresaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No EnquadramentoEmpresa found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}