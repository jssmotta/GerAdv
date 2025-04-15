﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ContatoCRMViewController(IContatoCRMViewService contatocrmviewService) : ControllerBase
{
    private readonly IContatoCRMViewService _contatocrmviewService = contatocrmviewService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ContatoCRMView", "GetAll", $"max = {max}", uri);
        var result = await _contatocrmviewService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterContatoCRMView filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ContatoCRMView: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _contatocrmviewService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ContatoCRMView: GetById called with id = {0}, {1}", id, uri);
        var result = await _contatocrmviewService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ContatoCRMView found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ContatoCRMView regContatoCRMView, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ContatoCRMView", "AddAndUpdate", regContatoCRMView, uri);
        var result = await _contatocrmviewService.AddAndUpdate(regContatoCRMView, uri);
        if (result == null)
        {
            _logger.Warn("ContatoCRMView: AddAndUpdate failed to add or update ContatoCRMView, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("ContatoCRMView: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _contatocrmviewService.GetColumns(parameters, uri);
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
        _logger.Info("ContatoCRMView: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _contatocrmviewService.UpdateColumns(parameters, uri);
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
        _logger.Info("ContatoCRMView: Delete called with id = {0}, {2}", id, uri);
        var result = await _contatocrmviewService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ContatoCRMView found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}