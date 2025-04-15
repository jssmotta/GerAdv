#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ParteOponenteController(IParteOponenteService parteoponenteService) : ControllerBase
{
    private readonly IParteOponenteService _parteoponenteService = parteoponenteService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterParteOponente filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ParteOponente: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _parteoponenteService.Filter(filtro, uri);
        return Ok(result);
    }
}