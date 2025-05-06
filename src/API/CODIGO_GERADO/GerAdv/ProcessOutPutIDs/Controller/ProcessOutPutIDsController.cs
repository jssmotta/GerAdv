#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProcessOutPutIDsController(IProcessOutPutIDsService processoutputidsService) : ControllerBase
{
    private readonly IProcessOutPutIDsService _processoutputidsService = processoutputidsService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProcessOutPutIDs", "GetAll", $"max = {max}", uri);
        var result = await _processoutputidsService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProcessOutPutIDs filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutPutIDs: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _processoutputidsService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ProcessOutPutIDs: GetById called with id = {0}, {1}", id, uri);
        var result = await _processoutputidsService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ProcessOutPutIDs found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutPutIDs: GetByName called with name = {0}, {1}", name, uri);
        var result = await _processoutputidsService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ProcessOutPutIDs found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterProcessOutPutIDs? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ProcessOutPutIDs: GetListN called, max {max}, {filtro} uri");
        var result = await _processoutputidsService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ProcessOutPutIDs regProcessOutPutIDs, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ProcessOutPutIDs", "AddAndUpdate", regProcessOutPutIDs, uri);
        var result = await _processoutputidsService.AddAndUpdate(regProcessOutPutIDs, uri);
        if (result == null)
        {
            _logger.Warn("ProcessOutPutIDs: AddAndUpdate failed to add or update ProcessOutPutIDs, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ProcessOutPutIDs: Delete called with id = {0}, {2}", id, uri);
        var result = await _processoutputidsService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ProcessOutPutIDs found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}