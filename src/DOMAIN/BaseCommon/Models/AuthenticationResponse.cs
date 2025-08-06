namespace MenphisSI.BaseCommon;

public class AuthenticateResponse(OperadorResponse user, string token, string tipo, string uri)
{
    public int Id { get; set; } = user.Id;
    public string FirstName { get; set; } = user.Nome;
    public string Username { get; set; } = user.EMailNet;
    public string Tipo { get; set; } = tipo;
    public string Token { get; set; } = token;
    public bool Reset { get; set; }
    public string Uri { get; set; } = uri;
    public bool IsMaster { get; set; } = user.Master;
}

public class ValidaUsernameResponse()
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Uri { get; set; }
}