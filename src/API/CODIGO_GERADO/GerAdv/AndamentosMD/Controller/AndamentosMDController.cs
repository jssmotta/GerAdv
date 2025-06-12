#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class AndamentosMDController(IAndamentosMDService andamentosmdService) : ControllerBase
{
    private readonly IAndamentosMDService _andamentosmdService = andamentosmdService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("AndamentosMD", "GetAll", $"max = {max}", uri);
        var result = await _andamentosmdService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterAndamentosMD filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("AndamentosMD: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _andamentosmdService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("AndamentosMD: GetById called with id = {0}, {1}", id, uri);
        var result = await _andamentosmdService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No AndamentosMD found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterAndamentosMD? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"AndamentosMD: GetListN called, max {max}, {filtro} uri");
        var result = await _andamentosmdService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.AndamentosMD regAndamentosMD, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("AndamentosMD", "AddAndUpdate", regAndamentosMD, uri);
        try
        {
            var result = await _andamentosmdService.AddAndUpdate(regAndamentosMD, uri);
            if (result == null)
            {
                _logger.Warn("AndamentosMD: AddAndUpdate failed to add or update AndamentosMD, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "AndamentosMD: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("AndamentosMD: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _andamentosmdService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No AndamentosMD found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "AndamentosMD: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }
}