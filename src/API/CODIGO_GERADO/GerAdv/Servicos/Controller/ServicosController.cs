#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ServicosController(IServicosService servicosService) : ControllerBase
{
    private readonly IServicosService _servicosService = servicosService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Servicos", "GetAll", $"max = {max}", uri);
        var result = await _servicosService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterServicos filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("Servicos: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _servicosService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("Servicos: GetById called with id = {0}, {1}", id, uri);
        var result = await _servicosService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No Servicos found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{name}")]
    [Authorize]
    public async Task<IActionResult> GetByName(string name, [FromRoute, Required] string uri)
    {
        _logger.Info("Servicos: GetByName called with name = {0}, {1}", name, uri);
        var result = await _servicosService.GetByName(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByName: No Servicos found with name = {0}, {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetListN([FromQuery] int max, [FromBody] Filters.FilterServicos? filtro, [FromRoute, Required] string uri)
    {
        _logger.Info($"Servicos: GetListN called, max {max}, {filtro} uri");
        var result = await _servicosService.GetListN(max, filtro, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.Servicos regServicos, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("Servicos", "AddAndUpdate", regServicos, uri);
        var result = await _servicosService.AddAndUpdate(regServicos, uri);
        if (result == null)
        {
            _logger.Warn("Servicos: AddAndUpdate failed to add or update Servicos, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("Servicos: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _servicosService.GetColumns(parameters, uri);
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
        _logger.Info("Servicos: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _servicosService.UpdateColumns(parameters, uri);
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
        _logger.Info("Servicos: Delete called with id = {0}, {2}", id, uri);
        var result = await _servicosService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No Servicos found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}