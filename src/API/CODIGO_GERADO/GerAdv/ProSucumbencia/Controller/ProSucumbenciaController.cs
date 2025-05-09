﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProSucumbenciaController(IProSucumbenciaService prosucumbenciaService) : ControllerBase
{
    private readonly IProSucumbenciaService _prosucumbenciaService = prosucumbenciaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProSucumbencia", "GetAll", $"max = {max}", uri);
        var result = await _prosucumbenciaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProSucumbencia filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProSucumbencia: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _prosucumbenciaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProSucumbencia: GetById called with id = {0}, {1}", id, uri);
        var result = await _prosucumbenciaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProSucumbencia found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ProSucumbencia: GetByName called with name = {0}, {1}", name, uri);
        var result = await _prosucumbenciaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ProSucumbencia found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProSucumbencia? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ProSucumbencia: GetListN called, max {max}, {filtro} uri");
        var result = await _prosucumbenciaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProSucumbencia regProSucumbencia, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProSucumbencia", "AddAndUpdate", regProSucumbencia, uri);
        var result = await _prosucumbenciaService.AddAndUpdate(regProSucumbencia, uri);
        if (result == null)
        {
            _logger.Warn("ProSucumbencia: AddAndUpdate failed to add or update ProSucumbencia, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProSucumbencia: Delete called with id = {0}, {2}", id, uri);
        var result = await _prosucumbenciaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProSucumbencia found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}