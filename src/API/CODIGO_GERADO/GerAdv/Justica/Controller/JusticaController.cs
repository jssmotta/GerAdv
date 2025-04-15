#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class JusticaController(IJusticaService justicaService) : ControllerBase
{
    private readonly IJusticaService _justicaService = justicaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Justica", "GetAll", $"max = {max}", uri);
        var result = await _justicaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterJustica filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Justica: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _justicaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Justica: GetById called with id = {0}, {1}", id, uri);
        var result = await _justicaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Justica found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Justica: GetByName called with name = {0}, {1}", name, uri);
        var result = await _justicaService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Justica found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterJustica? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Justica: GetListN called, max {max}, {filtro} uri");
        var result = await _justicaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Justica regJustica, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Justica", "AddAndUpdate", regJustica, uri);
        var result = await _justicaService.AddAndUpdate(regJustica, uri);
        if (result == null)
        {
            _logger.Warn("Justica: AddAndUpdate failed to add or update Justica, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Justica: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _justicaService.GetColumns(parameters, uri);
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
        _logger.Info("Justica: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _justicaService.UpdateColumns(parameters, uri);
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
        _logger.Info("Justica: Delete called with id = {0}, {2}", id, uri);
        var result = await _justicaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Justica found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}