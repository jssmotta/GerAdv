namespace MenphisSI.BaseCommon;

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [HttpPost]
    public async Task<IActionResult> ResetSenha([FromBody] AuthenticateRequest model, [FromRoute] string uri)
    {
        _logger.Info("Authenticate {0} - {1}", model.Username, uri);

        _ = await _userService.ResetSenha(model, uri);

        var response = new AuthenticateResponse(new OperadorResponse { Id = 0, Nome = "Reset" }, "", "", uri)
        {
            Id = 0,
        };

        return Ok(response);

    }

    [HttpPost]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model, [FromRoute] string uri)
    {
        _logger.Info("Authenticate {0} - {1}", model.Username, uri);

        try
        {
            var response = await _userService.Authenticate(model, uri);

            response ??= new AuthenticateResponse(new OperadorResponse { Id = 0, Nome = "Joe Doe" }, "", "", uri)
                {
                    Id = 0,
                };

            //return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error on Authenticate");
            return BadRequest(new { message = "Error on Authenticate" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> ValidaUsername([FromBody] ValidaUsernameRequest model, [FromRoute] string uri)
    {
        _logger.Info("Authenticate {0} - {1}", model.Username, uri);

        try
        {
            var response = await _userService.ValidaUsername(model, uri);

            response ??= new ValidaUsernameResponse { Username = "", Uri = uri, Id = 0 };           

            return Ok(response);
        }
        catch (Exception ex)
        {
            var oCnn = Configuracoes.ConnectionByUri(uri);
            if (oCnn == null)
            {
                _logger.Error(ex, "Erro ao iniciar conexão com o banco de dados");
                return BadRequest(new { message = "Db Connection Error" });
            }
            _logger.Error(ex, "Error on Validade Username");
            return BadRequest(new { message = "Error on Username" });
        }
    }

    [HttpGet]
    [Authorize]
    public IActionResult Reset([FromRoute] string uri)
    {
        _logger.Info("User: Reset {0}", uri);
        var response = _userService.Reset(uri);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> SetPassword([FromBody] ResetPasswordRequest model, [FromRoute] string uri)
    {

        var dbOper = await _userService.GetById(model.Id, uri);
        if (dbOper == null || dbOper?.Id == 0)
        {
            return BadRequest(new { message = "Error setting password, operator" });
        }
        if (DevourerOne.IsSenhaFraca(model.Password.DecodeBase64(), dbOper!.Nome))
        {
            return BadRequest(new { message = "Weak passord" });
        }

        var response = await _userService.SetPassword(model.Id, model.Password.DecodeBase64(), uri);

        return !response ? BadRequest(new { message = "Error setting password" }) : Ok(response);
    }
}