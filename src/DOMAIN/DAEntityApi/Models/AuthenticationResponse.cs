namespace MenphisSI.GerEntityTools.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public bool Reset { get; set; }
    public string Uri { get; set; } = string.Empty;
}