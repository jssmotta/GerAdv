namespace MenphisSI.GerAdv;

public class ResetPasswordRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
