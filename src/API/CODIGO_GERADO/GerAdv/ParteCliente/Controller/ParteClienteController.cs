#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ParteClienteController(IParteClienteService parteclienteService) : ControllerBase
{
    private readonly IParteClienteService _parteclienteService = parteclienteService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterParteCliente filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ParteCliente: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _parteclienteService.Filter(filtro, uri);
        return Ok(result);
    }
}