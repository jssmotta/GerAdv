#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class TerceirosController(ITerceirosService terceirosService) : ControllerBase
{
    private readonly ITerceirosService _terceirosService = terceirosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Terceiros", "GetAll", $"max = {max}", uri);
        var result = await _terceirosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterTerceiros filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Terceiros: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _terceirosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Terceiros: GetById called with id = {0}, {1}", id, uri);
        var result = await _terceirosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Terceiros found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterTerceiros? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Terceiros: GetListN called, max {max}, {filtro} uri");
        var result = await _terceirosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Terceiros regTerceiros, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Terceiros", "AddAndUpdate", regTerceiros, uri);
        try
        {
            var result = await _terceirosService.AddAndUpdate(regTerceiros, uri);
            if (result == null)
            {
                _logger.Warn("Terceiros: AddAndUpdate failed to add or update Terceiros, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Terceiros: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Terceiros: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _terceirosService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Terceiros found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Terceiros: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }
}