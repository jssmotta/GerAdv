#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadorController(IOperadorService operadorService) : ControllerBase
{
    private readonly IOperadorService _operadorService = operadorService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Operador", "GetAll", $"max = {max}", uri);
        var result = await _operadorService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Operador: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadorService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Operador found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Operador: GetByName called with name = {0}, {1}", name, uri);
        var result = await _operadorService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Operador found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.Info($"Operador: GetListN called, max {max},  uri");
        var result = await _operadorService.GetListN(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Operador regOperador, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Operador", "AddAndUpdate", regOperador, uri);
        var result = await _operadorService.AddAndUpdate(regOperador, uri);
        if (result == null)
        {
            _logger.Warn("Operador: AddAndUpdate failed to add or update Operador, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Operador: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _operadorService.GetColumns(parameters, uri);
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
        _logger.Info("Operador: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _operadorService.UpdateColumns(parameters, uri);
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
        _logger.Info("Operador: Delete called with id = {0}, {2}", id, uri);
        var result = await _operadorService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Operador found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}