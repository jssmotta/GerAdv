namespace MenphisSI.GerEntityTools.Models;
public class AuthenticateRequest
{
#if (DEBUG)
    
    public string Username { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;

#else

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

#endif
}