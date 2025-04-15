#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class Diario2Controller(IDiario2Service diario2Service) : ControllerBase
{
    private readonly IDiario2Service _diario2Service = diario2Service;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Diario2", "GetAll", $"max = {max}", uri);
        var result = await _diario2Service.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterDiario2 filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Diario2: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _diario2Service.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Diario2: GetById called with id = {0}, {1}", id, uri);
        var result = await _diario2Service.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Diario2 found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Diario2: GetByName called with name = {0}, {1}", name, uri);
        var result = await _diario2Service.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Diario2 found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterDiario2? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Diario2: GetListN called, max {max}, {filtro} uri");
        var result = await _diario2Service.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Diario2 regDiario2, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Diario2", "AddAndUpdate", regDiario2, uri);
        var result = await _diario2Service.AddAndUpdate(regDiario2, uri);
        if (result == null)
        {
            _logger.Warn("Diario2: AddAndUpdate failed to add or update Diario2, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Diario2: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _diario2Service.GetColumns(parameters, uri);
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
        _logger.Info("Diario2: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _diario2Service.UpdateColumns(parameters, uri);
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
        _logger.Info("Diario2: Delete called with id = {0}, {2}", id, uri);
        var result = await _diario2Service.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Diario2 found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}