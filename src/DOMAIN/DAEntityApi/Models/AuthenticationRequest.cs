namespace MenphisSI.GerEntityTools.Models;
public class AuthenticateRequest
{
#if (DEBUG)
    
    public string Username { get; set; }
    
    public string Password { get; set; }

#else

    public string Username { get; set; }

    public string Password { get; set; }

#endif
}