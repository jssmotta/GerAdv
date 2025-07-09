namespace MenphisSI.BaseCommon;

public partial class UsersController
{
    [HttpPost]
    public async Task<IActionResult> ResetPassword([FromBody] AuthenticateRequest model, [FromRoute] string uri)
    {

        var authorization = Request.Headers["Authorization"].FirstOrDefault();
        var expectedToken = $"Bearer {Environment.GetEnvironmentVariable("Secret")}";
        if (authorization != expectedToken)
        {
            return Unauthorized(new { message = "Invalid token" });
        }

        _ = await _userService.ResetSenha(model, uri);

        var response = new AuthenticateResponse(new OperadorResponse { Id = 0, Nome = "RESET" }, "", "", uri)
        {
            Id = 0,
        };

        return Ok(response);

    }

    [HttpPost]
    public async Task<IActionResult> Authenticate3([FromBody] AuthenticateRequest model, [FromRoute] string uri)
    {      
        var authorization = Request.Headers["Authorization"].FirstOrDefault();
        var expectedToken = $"Bearer {Environment.GetEnvironmentVariable("Secret")}";
        if (authorization != expectedToken)
        {
            return Unauthorized(new { message = "Invalid token" });
        }

        try
        {
            var response = await _userService.Authenticate3(model, uri);

            response ??= new AuthenticateResponse(new OperadorResponse { Id = 0, Nome = "Joe Doe" }, "", "", uri)
            {
                Id = 0,
            };            

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

        var authorization = Request.Headers["Authorization"].FirstOrDefault();
        var expectedToken = $"Bearer {Environment.GetEnvironmentVariable("Secret")}";
        if (authorization.NotEquals(expectedToken))
        {
            return Unauthorized(new { message = "Invalid token " + Environment.GetEnvironmentVariable("Secret")?.Length });
        }

        try
        {
            var response = await _userService.ValidaUsername(model, uri);
            response ??= new ValidaUsernameResponse { Username = "", Uri = uri, Id = 0 };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error on Validade Username");
            return BadRequest(new { message = "Erro ao validar: " + ex.Message });
        }
    }
}

