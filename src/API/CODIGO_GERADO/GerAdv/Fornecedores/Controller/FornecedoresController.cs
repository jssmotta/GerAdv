#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class FornecedoresController(IFornecedoresService fornecedoresService) : ControllerBase
{
    private readonly IFornecedoresService _fornecedoresService = fornecedoresService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Fornecedores", "GetAll", $"max = {max}", uri);
        var result = await _fornecedoresService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterFornecedores filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Fornecedores: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _fornecedoresService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Fornecedores: GetById called with id = {0}, {1}", id, uri);
        var result = await _fornecedoresService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Fornecedores found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Fornecedores: GetByName called with name = {0}, {1}", name, uri);
        var result = await _fornecedoresService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Fornecedores found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterFornecedores? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Fornecedores: GetListN called, max {max}, {filtro} uri");
        var result = await _fornecedoresService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Fornecedores regFornecedores, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Fornecedores", "AddAndUpdate", regFornecedores, uri);
        var result = await _fornecedoresService.AddAndUpdate(regFornecedores, uri);
        if (result == null)
        {
            _logger.Warn("Fornecedores: AddAndUpdate failed to add or update Fornecedores, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Fornecedores: Delete called with id = {0}, {2}", id, uri);
        var result = await _fornecedoresService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Fornecedores found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}