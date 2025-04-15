﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class Auditor4KController(IAuditor4KService auditor4kService) : ControllerBase
{
    private readonly IAuditor4KService _auditor4kService = auditor4kService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Auditor4K", "GetAll", $"max = {max}", uri);
        var result = await _auditor4kService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAuditor4K filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Auditor4K: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _auditor4kService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Auditor4K: GetById called with id = {0}, {1}", id, uri);
        var result = await _auditor4kService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Auditor4K found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Auditor4K: GetByName called with name = {0}, {1}", name, uri);
        var result = await _auditor4kService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Auditor4K found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAuditor4K? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Auditor4K: GetListN called, max {max}, {filtro} uri");
        var result = await _auditor4kService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Auditor4K regAuditor4K, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Auditor4K", "AddAndUpdate", regAuditor4K, uri);
        var result = await _auditor4kService.AddAndUpdate(regAuditor4K, uri);
        if (result == null)
        {
            _logger.Warn("Auditor4K: AddAndUpdate failed to add or update Auditor4K, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Auditor4K: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _auditor4kService.GetColumns(parameters, uri);
        if (result == null)
        {
            _logger.Warn("GetColumns: No columns found for id = {0}, {1}", parameters.Id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> UpdateColumns([FromBody] UpdateColumnsRequest parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Auditor4K: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _auditor4kService.UpdateColumns(parameters, uri);
        if (!result)
        {
            _logger.Warn("UpdateColumns: Failed to update columns for id = {0}, {1}", parameters.Id, uri);
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Auditor4K: Delete called with id = {0}, {2}", id, uri);
        var result = await _auditor4kService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Auditor4K found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}