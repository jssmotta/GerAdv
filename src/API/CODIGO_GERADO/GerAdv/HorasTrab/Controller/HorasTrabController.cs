#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class HorasTrabController(IHorasTrabService horastrabService) : ControllerBase
{
    private readonly IHorasTrabService _horastrabService = horastrabService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("HorasTrab", "GetAll", $"max = {max}", uri);
        var result = await _horastrabService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterHorasTrab filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("HorasTrab: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _horastrabService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("HorasTrab: GetById called with id = {0}, {1}", id, uri);
        var result = await _horastrabService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No HorasTrab found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.HorasTrab regHorasTrab, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("HorasTrab", "AddAndUpdate", regHorasTrab, uri);
        var result = await _horastrabService.AddAndUpdate(regHorasTrab, uri);
        if (result == null)
        {
            _logger.Warn("HorasTrab: AddAndUpdate failed to add or update HorasTrab, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("HorasTrab: Delete called with id = {0}, {2}", id, uri);
        var result = await _horastrabService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No HorasTrab found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}