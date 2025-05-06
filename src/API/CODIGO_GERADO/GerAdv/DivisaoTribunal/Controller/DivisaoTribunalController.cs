#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class DivisaoTribunalController(IDivisaoTribunalService divisaotribunalService) : ControllerBase
{
    private readonly IDivisaoTribunalService _divisaotribunalService = divisaotribunalService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("DivisaoTribunal", "GetAll", $"max = {max}", uri);
        var result = await _divisaotribunalService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterDivisaoTribunal filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("DivisaoTribunal: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _divisaotribunalService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("DivisaoTribunal: GetById called with id = {0}, {1}", id, uri);
        var result = await _divisaotribunalService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No DivisaoTribunal found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.DivisaoTribunal regDivisaoTribunal, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("DivisaoTribunal", "AddAndUpdate", regDivisaoTribunal, uri);
        var result = await _divisaotribunalService.AddAndUpdate(regDivisaoTribunal, uri);
        if (result == null)
        {
            _logger.Warn("DivisaoTribunal: AddAndUpdate failed to add or update DivisaoTribunal, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("DivisaoTribunal: Delete called with id = {0}, {2}", id, uri);
        var result = await _divisaotribunalService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No DivisaoTribunal found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}