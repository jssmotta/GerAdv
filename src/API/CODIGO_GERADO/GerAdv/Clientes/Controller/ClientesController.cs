﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ClientesController(IClientesService clientesService) : ControllerBase
{
    private readonly IClientesService _clientesService = clientesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Clientes", "GetAll", $"max = {max}", uri);
        var result = await _clientesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterClientes filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Clientes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _clientesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Clientes: GetById called with id = {0}, {1}", id, uri);
        var result = await _clientesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Clientes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Clientes: GetByName called with name = {0}, {1}", name, uri);
        var result = await _clientesService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Clientes found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterClientes? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Clientes: GetListN called, max {max}, {filtro} uri");
        var result = await _clientesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Clientes regClientes, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Clientes", "AddAndUpdate", regClientes, uri);
        var result = await _clientesService.AddAndUpdate(regClientes, uri);
        if (result == null)
        {
            _logger.Warn("Clientes: AddAndUpdate failed to add or update Clientes, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Clientes: Delete called with id = {0}, {2}", id, uri);
        var result = await _clientesService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Clientes found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}