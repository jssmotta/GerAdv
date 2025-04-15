#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ProBarCODEController(IProBarCODEService probarcodeService) : ControllerBase
{
    private readonly IProBarCODEService _probarcodeService = probarcodeService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterProBarCODE filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ProBarCODE: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _probarcodeService.Filter(filtro, uri);
        return Ok(result);
    }
}