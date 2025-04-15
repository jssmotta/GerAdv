using System.ComponentModel;

namespace MenphisSI.BaseCommon;

public class AuthenticateRequest
{
#if (DEBUG)

    [DefaultValue("test@menphis.com.br")]
    public required string Username { get; set; }

    [DefaultValue("1231231213212331232313232")]
    public required string Password { get; set; }

#else

    public required string Username { get; set; }

    public required string Password { get; set; }

#endif
}

public class ValidaUsernameRequest
{
    public required string Username { get; set; }
}