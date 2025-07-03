#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EnderecosController(IEnderecosService enderecosService) : ControllerBase
{
    private readonly IEnderecosService _enderecosService = enderecosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Enderecos", "GetAll", $"max = {max}", uri);
        var result = await _enderecosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEnderecos filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info("Enderecos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _enderecosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        //_logger.Info("Enderecos: GetById called with id = {0}, {1}", id, uri);
        var result = await _enderecosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Enderecos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterEnderecos? filtro, [FromRoute, Required] string uri)
    {
        //_logger.Info($"Enderecos: GetListN called, max {max}, {filtro} uri");
        var result = await _enderecosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Enderecos regEnderecos, [FromRoute, Required] string uri)
    {
        //_logger.LogInfo("Enderecos", "AddAndUpdate", regEnderecos, uri);
        try
        {
            var result = await _enderecosService.AddAndUpdate(regEnderecos, uri);
            if (result == null)
            {
                _logger.Warn("Enderecos: AddAndUpdate failed to add or update Enderecos, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Enderecos: AddAndUpdate failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }

    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        //_logger.Info("Enderecos: Delete called with id = {0}, {2}", id, uri);
        try
        {
            var result = await _enderecosService.Delete(id, uri);
            if (result == null)
            {
                _logger.Warn("Delete: No Enderecos found to delete with id = {0}, {1}", id, uri);
                return NotFound();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Enderecos: Delete failed with exception for id = {0}, {1}", id, uri);
            return Conflict(new { success = false, data = "", message = "Não é possível excluir o registro porque ele está sendo referenciado/em uso em outra tabela." });
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Validation([FromBody] Models.Enderecos regEnderecos, [FromRoute, Required] string uri)
    {
        try
        {
            var result = await _enderecosService.Validation(regEnderecos, uri);
            if (result == null)
            {
                _logger.Warn("Enderecos: Validation failed to add or update Enderecos, {0}", uri);
                return BadRequest();
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Enderecos: Validation failed with exception for uri = {0}", uri);
            return StatusCode(500, new { success = false, data = "", message = ex.Message });
        }
    }
}