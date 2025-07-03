#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AreaController(IAreaService areaService) : ControllerBase
{
    private readonly IAreaService _areaService = areaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Area", "GetAll", $"max = {max}", uri);
        var result = await _areaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterArea filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Area: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _areaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Area: GetById called with id = {0}, {1}", id, uri);
        var result = await _areaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Area found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterArea? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Area: GetListN called, max {max}, {filtro} uri");
        var result = await _areaService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Area regArea, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Area", "AddAndUpdate", regArea, uri);
        try
        {
            var result = await _areaService.AddAndUpdate(regArea, uri);
            if (result == null)
            {
                _logger.Warn("Area: AddAndUpdate failed to add or update Area, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Area: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Area: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _areaService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Area found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Area: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Area regArea, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _areaService.Validation(regArea, uri);
            if (result == null)
            {
                _logger.Warn("Area: Validation failed to add or update Area, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Area: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}