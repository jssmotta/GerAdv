namespace MenphisSI.GerEntityTools.Models;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Username { get; set; }
    public string Tipo { get; set; }
    public string Token { get; set; }
    public bool Reset { get; set; }
    public string Uri { get; set; }
}