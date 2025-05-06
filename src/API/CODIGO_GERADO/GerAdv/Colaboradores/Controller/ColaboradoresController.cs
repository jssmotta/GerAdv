#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ColaboradoresController(IColaboradoresService colaboradoresService) : ControllerBase
{
    private readonly IColaboradoresService _colaboradoresService = colaboradoresService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Colaboradores", "GetAll", $"max = {max}", uri);
        var result = await _colaboradoresService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterColaboradores filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Colaboradores: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _colaboradoresService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Colaboradores: GetById called with id = {0}, {1}", id, uri);
        var result = await _colaboradoresService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Colaboradores found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Colaboradores: GetByName called with name = {0}, {1}", name, uri);
        var result = await _colaboradoresService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Colaboradores found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterColaboradores? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Colaboradores: GetListN called, max {max}, {filtro} uri");
        var result = await _colaboradoresService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Colaboradores regColaboradores, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Colaboradores", "AddAndUpdate", regColaboradores, uri);
        var result = await _colaboradoresService.AddAndUpdate(regColaboradores, uri);
        if (result == null)
        {
            _logger.Warn("Colaboradores: AddAndUpdate failed to add or update Colaboradores, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("Colaboradores: Delete called with id = {0}, {2}", id, uri);
        var result = await _colaboradoresService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Colaboradores found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}