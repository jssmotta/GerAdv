#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class LivroCaixaClientesController(ILivroCaixaClientesService livrocaixaclientesService) : ControllerBase
{
    private readonly ILivroCaixaClientesService _livrocaixaclientesService = livrocaixaclientesService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("LivroCaixaClientes", "GetAll", $"max = {max}", uri);
        var result = await _livrocaixaclientesService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterLivroCaixaClientes filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("LivroCaixaClientes: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _livrocaixaclientesService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("LivroCaixaClientes: GetById called with id = {0}, {1}", id, uri);
        var result = await _livrocaixaclientesService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No LivroCaixaClientes found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.LivroCaixaClientes regLivroCaixaClientes, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("LivroCaixaClientes", "AddAndUpdate", regLivroCaixaClientes, uri);
        try
        {
            var result = await _livrocaixaclientesService.AddAndUpdate(regLivroCaixaClientes, uri);
            if (result == null)
            {
                _logger.Warn("LivroCaixaClientes: AddAndUpdate failed to add or update LivroCaixaClientes, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "LivroCaixaClientes: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("LivroCaixaClientes: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _livrocaixaclientesService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No LivroCaixaClientes found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "LivroCaixaClientes: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }
}