#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class LivroCaixaController(ILivroCaixaService livrocaixaService) : ControllerBase
{
    private readonly ILivroCaixaService _livrocaixaService = livrocaixaService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("LivroCaixa", "GetAll", $"max = {max}", uri);
        var result = await _livrocaixaService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterLivroCaixa filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("LivroCaixa: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _livrocaixaService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("LivroCaixa: GetById called with id = {0}, {1}", id, uri);
        var result = await _livrocaixaService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No LivroCaixa found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.LivroCaixa regLivroCaixa, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("LivroCaixa", "AddAndUpdate", regLivroCaixa, uri);
        var result = await _livrocaixaService.AddAndUpdate(regLivroCaixa, uri);
        if (result == null)
        {
            _logger.Warn("LivroCaixa: AddAndUpdate failed to add or update LivroCaixa, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("LivroCaixa: Delete called with id = {0}, {2}", id, uri);
        var result = await _livrocaixaService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No LivroCaixa found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}