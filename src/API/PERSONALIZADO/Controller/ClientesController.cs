namespace MenphisSI.GerMDS.Controller;

public partial class ClientesController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Pesquisa(PesquisaModel texto, [FromRoute] string uri)
    {
        _logger.Info("Clientes: Pesquisa - {0}", uri);
        var result = await _clientesService.Pesquisa(texto.Texto, uri);
        return Ok(result);
    }

    [HttpGet("nomesobrenome/{name}")]
    [Authorize]
    public async Task<IActionResult> GetByNomeSobrenome(string name, [FromRoute] string uri)
    {
        _logger.Info("Clientes: GetByNomeSobrenome called with name = {0}, {1}", name, uri);
        var result = await _clientesService.GetByNomeSobrenome(name, uri);
        if (result == null)
        {
            _logger.Warn("GetByNomeSobrenome: No Clientes found with name = {0} - {1}", name, uri);
            return NotFound();
        }

        return Ok(result);
    }

//    [HttpGet]
//    [Authorize]
//    public async Task<IActionResult> Leao(string data, string dataFinal, bool comRecibo, [FromRoute] string uri)
//    {
//        if (_clientesService == null)
//        {
//            _logger.Error("Leao: _clientesService is null - {0}", uri);
//            return NotFound();
//        }
//        _logger.Info("Leao: Leao called with name = {0}, {1}", data, dataFinal, uri);
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//        var result = await _clientesService.Leao(data, dataFinal, comRecibo, uri);
//#pragma warning restore CS8602 // Dereference of a possibly null reference.
//        if (result == null)
//        {
//            _logger.Warn("Leao: No Clientes found with name = {0} - {1}", data, uri);
//            return NotFound();
//        }

//        return Ok(result);
//    }
}

public class PesquisaModel
{
    [JsonPropertyName("texto")]
    public string Texto { get; set; } = "";
}
