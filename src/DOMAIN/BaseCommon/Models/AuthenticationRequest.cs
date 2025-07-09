using System.ComponentModel;

namespace MenphisSI.BaseCommon;

public class AuthenticateRequest
{
#if (DEBUG)

    [DefaultValue("test@menphis.com.br")]
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [DefaultValue("1231231213212331232313232")]
    [JsonPropertyName("password")]
    public required string Password { get; set; }

    [JsonPropertyName("currentPassword")]
    public string CurrentPassword { get; set; } = "";

    [JsonPropertyName("validCurrentPassword")]
    public bool ValidCurrentPassword { get; set; } = false;

#else

    [JsonPropertyName("username")]
    public required string Username { get; set; }
    [JsonPropertyName("password")]
    public required string Password { get; set; }

    [JsonPropertyName("currentPassword")]
    public string CurrentPassword { get; set; } = "";

    [JsonPropertyName("validCurrentPassword")]
    public bool ValidCurrentPassword { get; set; } = false;

#endif
}

public class ValidaUsernameRequest
{
    public required string Username { get; set; }
}