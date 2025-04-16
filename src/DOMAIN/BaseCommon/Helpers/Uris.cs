 namespace MenphisSI.BaseCommon;

public static class Uris
{ 
    public static string[] WebClientsUri => [
#if (DEBUG)
        "http://localhost:3000",
#endif
        $"https://{MenphisSI.GerAdv.Client.EntityApi.BaseUrlApi}",
        "ajfanibrahim.com.br", "www.ajfanibrahim.com.br"];

    public static bool ValidaUri(string? uri, string uris)
    {
        return !string.IsNullOrEmpty(uri) && uris.ToUpper().Split(';').Contains(uri.ToUpper());
    }
}
