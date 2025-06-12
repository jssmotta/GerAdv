#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class DocumentosController(IDocumentosService documentosService) : ControllerBase
{
    private readonly IDocumentosService _documentosService = documentosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Documentos", "GetAll", $"max = {max}", uri);
        var result = await _documentosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterDocumentos filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Documentos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _documentosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Documentos: GetById called with id = {0}, {1}", id, uri);
        var result = await _documentosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Documentos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Documentos regDocumentos, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Documentos", "AddAndUpdate", regDocumentos, uri);
        try
        {
            var result = await _documentosService.AddAndUpdate(regDocumentos, uri);
            if (result == null)
            {
                _logger.Warn("Documentos: AddAndUpdate failed to add or update Documentos, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Documentos: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Documentos: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _documentosService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Documentos found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Documentos: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }
}