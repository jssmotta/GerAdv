#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class LigacoesController(ILigacoesService ligacoesService) : ControllerBase
{
    private readonly ILigacoesService _ligacoesService = ligacoesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Ligacoes", "GetAll", $"max = {max}", uri);
        var result = await _ligacoesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterLigacoes filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Ligacoes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _ligacoesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Ligacoes: GetById called with id = {0}, {1}", id, uri);
        var result = await _ligacoesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Ligacoes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Ligacoes: GetByName called with name = {0}, {1}", name, uri);
        var result = await _ligacoesService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Ligacoes found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterLigacoes? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Ligacoes: GetListN called, max {max}, {filtro} uri");
        var result = await _ligacoesService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Ligacoes regLigacoes, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Ligacoes", "AddAndUpdate", regLigacoes, uri);
        var result = await _ligacoesService.AddAndUpdate(regLigacoes, uri);
        if (result == null)
        {
            _logger.Warn("Ligacoes: AddAndUpdate failed to add or update Ligacoes, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Ligacoes: Delete called with id = {0}, {2}", id, uri);
        var result = await _ligacoesService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Ligacoes found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}