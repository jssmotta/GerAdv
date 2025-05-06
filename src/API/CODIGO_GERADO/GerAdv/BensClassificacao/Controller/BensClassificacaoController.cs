#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class BensClassificacaoController(IBensClassificacaoService bensclassificacaoService) : ControllerBase
{
    private readonly IBensClassificacaoService _bensclassificacaoService = bensclassificacaoService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("BensClassificacao", "GetAll", $"max = {max}", uri);
        var result = await _bensclassificacaoService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterBensClassificacao filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("BensClassificacao: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _bensclassificacaoService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("BensClassificacao: GetById called with id = {0}, {1}", id, uri);
        var result = await _bensclassificacaoService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No BensClassificacao found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("BensClassificacao: GetByName called with name = {0}, {1}", name, uri);
        var result = await _bensclassificacaoService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No BensClassificacao found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterBensClassificacao? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"BensClassificacao: GetListN called, max {max}, {filtro} uri");
        var result = await _bensclassificacaoService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.BensClassificacao regBensClassificacao, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("BensClassificacao", "AddAndUpdate", regBensClassificacao, uri);
        var result = await _bensclassificacaoService.AddAndUpdate(regBensClassificacao, uri);
        if (result == null)
        {
            _logger.Warn("BensClassificacao: AddAndUpdate failed to add or update BensClassificacao, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("BensClassificacao: Delete called with id = {0}, {2}", id, uri);
        var result = await _bensclassificacaoService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No BensClassificacao found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}