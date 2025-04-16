#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OponentesRepLegalController(IOponentesRepLegalService oponentesreplegalService) : ControllerBase
{
    private readonly IOponentesRepLegalService _oponentesreplegalService = oponentesreplegalService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OponentesRepLegal", "GetAll", $"max = {max}", uri);
        var result = await _oponentesreplegalService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOponentesRepLegal filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("OponentesRepLegal: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _oponentesreplegalService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("OponentesRepLegal: GetById called with id = {0}, {1}", id, uri);
        var result = await _oponentesreplegalService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No OponentesRepLegal found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("OponentesRepLegal: GetByName called with name = {0}, {1}", name, uri);
        var result = await _oponentesreplegalService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No OponentesRepLegal found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterOponentesRepLegal? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"OponentesRepLegal: GetListN called, max {max}, {filtro} uri");
        var result = await _oponentesreplegalService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.OponentesRepLegal regOponentesRepLegal, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OponentesRepLegal", "AddAndUpdate", regOponentesRepLegal, uri);
        var result = await _oponentesreplegalService.AddAndUpdate(regOponentesRepLegal, uri);
        if (result == null)
        {
            _logger.Warn("OponentesRepLegal: AddAndUpdate failed to add or update OponentesRepLegal, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("OponentesRepLegal: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _oponentesreplegalService.GetColumns(parameters, uri);
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
        _logger.Info("OponentesRepLegal: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _oponentesreplegalService.UpdateColumns(parameters, uri);
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
        _logger.Info("OponentesRepLegal: Delete called with id = {0}, {2}", id, uri);
        var result = await _oponentesreplegalService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No OponentesRepLegal found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}