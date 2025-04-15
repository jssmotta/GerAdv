#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class GruposEmpresasController(IGruposEmpresasService gruposempresasService) : ControllerBase
{
    private readonly IGruposEmpresasService _gruposempresasService = gruposempresasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GruposEmpresas", "GetAll", $"max = {max}", uri);
        var result = await _gruposempresasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterGruposEmpresas filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresas: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _gruposempresasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("GruposEmpresas: GetById called with id = {0}, {1}", id, uri);
        var result = await _gruposempresasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No GruposEmpresas found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresas: GetByName called with name = {0}, {1}", name, uri);
        var result = await _gruposempresasService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No GruposEmpresas found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterGruposEmpresas? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"GruposEmpresas: GetListN called, max {max}, {filtro} uri");
        var result = await _gruposempresasService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.GruposEmpresas regGruposEmpresas, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("GruposEmpresas", "AddAndUpdate", regGruposEmpresas, uri);
        var result = await _gruposempresasService.AddAndUpdate(regGruposEmpresas, uri);
        if (result == null)
        {
            _logger.Warn("GruposEmpresas: AddAndUpdate failed to add or update GruposEmpresas, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresas: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _gruposempresasService.GetColumns(parameters, uri);
        if (result == null)
        {
            _logger.Warn("GetColumns: No columns found for id = {0}, {1}", parameters.Id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost()]
    [Authorize]
    public async Task<IActionResult> UpdateColumns([FromBody] UpdateColumnsRequest parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresas: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _gruposempresasService.UpdateColumns(parameters, uri);
        if (!result)
        {
            _logger.Warn("UpdateColumns: Failed to update columns for id = {0}, {1}", parameters.Id, uri);
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] int id, [FromRoute, Required] string uri)
    {
        _logger.Info("GruposEmpresas: Delete called with id = {0}, {2}", id, uri);
        var result = await _gruposempresasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No GruposEmpresas found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}