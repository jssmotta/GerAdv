#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class OperadorEMailPopupController(IOperadorEMailPopupService operadoremailpopupService) : ControllerBase
{
    private readonly IOperadorEMailPopupService _operadoremailpopupService = operadoremailpopupService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorEMailPopup", "GetAll", $"max = {max}", uri);
        var result = await _operadoremailpopupService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterOperadorEMailPopup filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorEMailPopup: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _operadoremailpopupService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("OperadorEMailPopup: GetById called with id = {0}, {1}", id, uri);
        var result = await _operadoremailpopupService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No OperadorEMailPopup found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorEMailPopup: GetByName called with name = {0}, {1}", name, uri);
        var result = await _operadoremailpopupService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No OperadorEMailPopup found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterOperadorEMailPopup? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"OperadorEMailPopup: GetListN called, max {max}, {filtro} uri");
        var result = await _operadoremailpopupService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.OperadorEMailPopup regOperadorEMailPopup, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("OperadorEMailPopup", "AddAndUpdate", regOperadorEMailPopup, uri);
        var result = await _operadoremailpopupService.AddAndUpdate(regOperadorEMailPopup, uri);
        if (result == null)
        {
            _logger.Warn("OperadorEMailPopup: AddAndUpdate failed to add or update OperadorEMailPopup, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("OperadorEMailPopup: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _operadoremailpopupService.GetColumns(parameters, uri);
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
        _logger.Info("OperadorEMailPopup: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _operadoremailpopupService.UpdateColumns(parameters, uri);
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
        _logger.Info("OperadorEMailPopup: Delete called with id = {0}, {2}", id, uri);
        var result = await _operadoremailpopupService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No OperadorEMailPopup found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}