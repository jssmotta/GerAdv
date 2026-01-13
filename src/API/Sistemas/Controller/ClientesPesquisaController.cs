//using MenphisSI.ClientesPesquisa.Interface;

//namespace MenphisSI.Pesquisa.Controller;

//[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
//[ApiController]
//[ApiVersion("1.0")]
//[ExcludeFromCodeCoverage]
//public partial class ClientesPesquisaController(IClientesPesquisaService clientesService) : ControllerBase
//{ 
//    private readonly IClientesPesquisaService _clientesService = clientesService;    

//    [HttpPost]
//    [Authorize]
//    public async Task<IActionResult> Pesquisa(PesquisaModel texto, [FromRoute] string uri)
//    {
//        //_logger.Info("Clientes: Pesquisa - {0}", uri);
//        var result = await _clientesService.Pesquisa(texto.Texto, uri);
//        return Ok(result);
//    }

//    [HttpGet("nomesobrenome/{name}")]
//    [Authorize]
//    public async Task<IActionResult> GetByNomeSobrenome(string name, [FromRoute] string uri)
//    {
//        //_logger.Info("Clientes: GetByNomeSobrenome called with name = {0}, {1}", name, uri);
//        var result = await _clientesService.GetByNomeSobrenome(name, uri);
//        if (result == null)
//        {
//            //_logger.Warn("GetByNomeSobrenome: No Clientes found with name = {0} - {1}", name, uri);
//            return NotFound();
//        }

//        return Ok(result);
//    }

//}

//public class PesquisaModel
//{
//    [JsonPropertyName("texto")]
//    public string Texto { get; set; } = "";
//}
