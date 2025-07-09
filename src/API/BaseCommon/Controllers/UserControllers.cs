namespace MenphisSI.BaseCommon;

[Route("api/v{version:apiVersion}/{uri}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public partial class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();    

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] AuthenticateRequest model, [FromRoute] string uri)
    {
        _logger.Info("ChangePassword {0} - {1}", model.Username, uri);

        var response = await _userService.ChangePassword(model, uri);     
        if (response == null)
        {
            return BadRequest(new { message = "Error on Change Password" });
        }

        return Ok(response);
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