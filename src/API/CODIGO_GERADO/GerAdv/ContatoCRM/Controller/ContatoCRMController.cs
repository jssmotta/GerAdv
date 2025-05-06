#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ContatoCRMController(IContatoCRMService contatocrmService) : ControllerBase
{
    private readonly IContatoCRMService _contatocrmService = contatocrmService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ContatoCRM", "GetAll", $"max = {max}", uri);
        var result = await _contatocrmService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterContatoCRM filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ContatoCRM: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _contatocrmService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ContatoCRM: GetById called with id = {0}, {1}", id, uri);
        var result = await _contatocrmService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ContatoCRM found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ContatoCRM regContatoCRM, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ContatoCRM", "AddAndUpdate", regContatoCRM, uri);
        var result = await _contatocrmService.AddAndUpdate(regContatoCRM, uri);
        if (result == null)
        {
            _logger.Warn("ContatoCRM: AddAndUpdate failed to add or update ContatoCRM, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ContatoCRM: Delete called with id = {0}, {2}", id, uri);
        var result = await _contatocrmService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ContatoCRM found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}