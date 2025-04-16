#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class ReuniaoPessoasController(IReuniaoPessoasService reuniaopessoasService) : ControllerBase
{
    private readonly IReuniaoPessoasService _reuniaopessoasService = reuniaopessoasService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] int max, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ReuniaoPessoas", "GetAll", $"max = {max}", uri);
        var result = await _reuniaopessoasService.GetAll(max, uri);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Filter([FromBody] Filters.FilterReuniaoPessoas filtro, [FromRoute, Required] string uri)
    {
        _logger.Info("ReuniaoPessoas: Filter called with filtro = {0}, {1}", filtro, uri);
        var result = await _reuniaopessoasService.Filter(filtro, uri);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id, [FromRoute, Required] string uri, CancellationToken token = default)
    {
        _logger.Info("ReuniaoPessoas: GetById called with id = {0}, {1}", id, uri);
        var result = await _reuniaopessoasService.GetById(id, uri, token);
        if (result == null)
        {
            _logger.Warn("GetById: No ReuniaoPessoas found with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddAndUpdate([FromBody] Models.ReuniaoPessoas regReuniaoPessoas, [FromRoute, Required] string uri)
    {
        _logger.LogInfo("ReuniaoPessoas", "AddAndUpdate", regReuniaoPessoas, uri);
        var result = await _reuniaopessoasService.AddAndUpdate(regReuniaoPessoas, uri);
        if (result == null)
        {
            _logger.Warn("ReuniaoPessoas: AddAndUpdate failed to add or update ReuniaoPessoas, {0}", uri);
            return BadRequest();
        }

        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> GetColumns([FromBody] GetColumns parameters, [FromRoute, Required] string uri)
    {
        _logger.Info("ReuniaoPessoas: GetColumns called with id = {0} and columns = {1}, {2}", parameters.Id, parameters.Columns, uri);
        var result = await _reuniaopessoasService.GetColumns(parameters, uri);
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
        _logger.Info("ReuniaoPessoas: UpdateColumns called with id = {0} and campos = {1}, {2}", parameters.Id, parameters, uri);
        var result = await _reuniaopessoasService.UpdateColumns(parameters, uri);
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
        _logger.Info("ReuniaoPessoas: Delete called with id = {0}, {2}", id, uri);
        var result = await _reuniaopessoasService.Delete(id, uri);
        if (result == null)
        {
            _logger.Warn("Delete: No ReuniaoPessoas found to delete with id = {0}, {1}", id, uri);
            return NotFound();
        }

        return Ok(result);
    }
}