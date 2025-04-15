#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GUTPeriodicidadeController(IGUTPeriodicidadeService gutperiodicidadeService) : ControllerBase
{
    private readonly IGUTPeriodicidadeService _gutperiodicidadeService = gutperiodicidadeService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GUTPeriodicidade", "GetAll", $"max = {max}", uri);
        var result = await _gutperiodicidadeService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGUTPeriodicidade filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTPeriodicidade: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gutperiodicidadeService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("GUTPeriodicidade: GetById called with id = {0}, {1}", id, uri);
        var result = await _gutperiodicidadeService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GUTPeriodicidade found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTPeriodicidade: GetByName called with name = {0}, {1}", name, uri);
        var result = await _gutperiodicidadeService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No GUTPeriodicidade found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterGUTPeriodicidade? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"GUTPeriodicidade: GetListN called, max {max}, {filtro} uri");
        var result = await _gutperiodicidadeService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GUTPeriodicidade regGUTPeriodicidade, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GUTPeriodicidade", "AddAndUpdate", regGUTPeriodicidade, uri);
        var result = await _gutperiodicidadeService.AddAndUpdate(regGUTPeriodicidade, uri);
        if (result == null)
        {
            _logger.Warn("GUTPeriodicidade: AddAndUpdate failed to add or update GUTPeriodicidade, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("GUTPeriodicidade: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _gutperiodicidadeService.GetColumns(parameters, uri);
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
        _logger.Info("GUTPeriodicidade: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _gutperiodicidadeService.UpdateColumns(parameters, uri);
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
        _logger.Info("GUTPeriodicidade: Delete called with id = {0}, {2}", id, uri);
        var result = await _gutperiodicidadeService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No GUTPeriodicidade found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}