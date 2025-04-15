namespace MenphisSI.GerAdv.Controller;

public partial class AgendaSemanaController : ControllerBase
{

    [HttpPost("{data}")]
    [Authorize]
    public async Task<IActionResult> Filter30(string data, int paciente, int isMobile, string uri)
    {
        if (DateTime.TryParse(data, out var dia))
        {
            _logger.Info("AgendaSemana: Filter30 called with filtro = {0}", dia);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var result = await _agendasemanaService.Filter30(Convert.ToDateTime(dia), paciente, isMobile, uri) ?? [];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            return Ok(result);
        }
        return BadRequest("Data inválida");
    }
    [HttpPost("{dataInicial}")]
    [Authorize]
    public async Task<IActionResult> Monta(string dataInicial, bool isMobile, string uri)
    {
        if (DateTime.TryParseExact(dataInicial, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out var data) == false)
        {
            return BadRequest("DataInicial inválida");
        }

        _logger.Info("AgendaSemana: Monta called with dataInicial = {0}", data);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var result = await _agendasemanaService.Monta(data, isMobile, uri);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        return Ok(result);
    }

}