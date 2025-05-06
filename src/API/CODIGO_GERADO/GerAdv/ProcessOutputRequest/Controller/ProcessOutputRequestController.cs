#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProcessOutputRequestController(IProcessOutputRequestService processoutputrequestService) : ControllerBase
{
    private readonly IProcessOutputRequestService _processoutputrequestService = processoutputrequestService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProcessOutputRequest", "GetAll", $"max = {max}", uri);
        var result = await _processoutputrequestService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProcessOutputRequest filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutputRequest: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _processoutputrequestService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProcessOutputRequest: GetById called with id = {0}, {1}", id, uri);
        var result = await _processoutputrequestService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProcessOutputRequest found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProcessOutputRequest regProcessOutputRequest, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProcessOutputRequest", "AddAndUpdate", regProcessOutputRequest, uri);
        var result = await _processoutputrequestService.AddAndUpdate(regProcessOutputRequest, uri);
        if (result == null)
        {
            _logger.Warn("ProcessOutputRequest: AddAndUpdate failed to add or update ProcessOutputRequest, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutputRequest: Delete called with id = {0}, {2}", id, uri);
        var result = await _processoutputrequestService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProcessOutputRequest found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}