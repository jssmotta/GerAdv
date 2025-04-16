#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class EMPClassRiscosController(IEMPClassRiscosService empclassriscosService) : ControllerBase
{
    private readonly IEMPClassRiscosService _empclassriscosService = empclassriscosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EMPClassRiscos", "GetAll", $"max = {max}", uri);
        var result = await _empclassriscosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterEMPClassRiscos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("EMPClassRiscos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _empclassriscosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("EMPClassRiscos: GetById called with id = {0}, {1}", id, uri);
        var result = await _empclassriscosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No EMPClassRiscos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("EMPClassRiscos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _empclassriscosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No EMPClassRiscos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterEMPClassRiscos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"EMPClassRiscos: GetListN called, max {max}, {filtro} uri");
        var result = await _empclassriscosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.EMPClassRiscos regEMPClassRiscos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("EMPClassRiscos", "AddAndUpdate", regEMPClassRiscos, uri);
        var result = await _empclassriscosService.AddAndUpdate(regEMPClassRiscos, uri);
        if (result == null)
        {
            _logger.Warn("EMPClassRiscos: AddAndUpdate failed to add or update EMPClassRiscos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("EMPClassRiscos: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _empclassriscosService.GetColumns(parameters, uri);
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
        _logger.Info("EMPClassRiscos: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _empclassriscosService.UpdateColumns(parameters, uri);
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
        _logger.Info("EMPClassRiscos: Delete called with id = {0}, {2}", id, uri);
        var result = await _empclassriscosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No EMPClassRiscos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}