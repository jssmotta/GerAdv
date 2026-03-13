//using MenphisSI.ClientesPesquisa.Interface;

//namespace MenphisSI.Pesquisa.Controller;

//[Route("api/v{version:apiVersion}/{tenantKey}/[controller]/[action]")]
//[ApiController]
//[ApiVersion("1.0")]
//[ExcludeFromCodeCoverage]
//public partial class ClientesPesquisaController(IClientesPesquisaService clientesService) : ControllerBase
//{ 
//    private readonly IClientesPesquisaService _clientesService = clientesService;    

//    [HttpPost]
//    [Authorize]
//    public async Task<IActionResult> Pesquisa(PesquisaModel texto, [FromRoute] string tenantKey)
//    {
//        //_logger.Info("Clientes: Pesquisa - {0}", tenantKey);
//        var result = await _clientesService.Pesquisa(texto.Texto, tenantKey);
//        return Ok(result);
//    }

//    [HttpGet("nomesobrenome/{name}")]
//    [Authorize]
//    public async Task<IActionResult> GetByNomeSobrenome(string name, [FromRoute] string tenantKey)
//    {
//        //_logger.Info("Clientes: GetByNomeSobrenome called with name = {0}, {1}", name, tenantKey);
//        var result = await _clientesService.GetByNomeSobrenome(name, tenantKey);
//        if (result == null)
//        {
//            //_logger.Warn("GetByNomeSobrenome: No Clientes found with name = {0} - {1}", name, tenantKey);
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
