#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ModelosDocumentosController(IModelosDocumentosService modelosdocumentosService) : ControllerBase
{
    private readonly IModelosDocumentosService _modelosdocumentosService = modelosdocumentosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ModelosDocumentos", "GetAll", $"max = {max}", uri);
        var result = await _modelosdocumentosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterModelosDocumentos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ModelosDocumentos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _modelosdocumentosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ModelosDocumentos: GetById called with id = {0}, {1}", id, uri);
        var result = await _modelosdocumentosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ModelosDocumentos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("ModelosDocumentos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _modelosdocumentosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No ModelosDocumentos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterModelosDocumentos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"ModelosDocumentos: GetListN called, max {max}, {filtro} uri");
        var result = await _modelosdocumentosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ModelosDocumentos regModelosDocumentos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ModelosDocumentos", "AddAndUpdate", regModelosDocumentos, uri);
        var result = await _modelosdocumentosService.AddAndUpdate(regModelosDocumentos, uri);
        if (result == null)
        {
            _logger.Warn("ModelosDocumentos: AddAndUpdate failed to add or update ModelosDocumentos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("ModelosDocumentos: Delete called with id = {0}, {2}", id, uri);
        var result = await _modelosdocumentosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ModelosDocumentos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}