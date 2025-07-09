using MenphisSI.GerEntityTools.Entity;

namespace MenphisSI.BaseCommon;

public static class Uris
{
    public static string ProdutoURIs { get; set; } = string.Empty;
    private static DateTime UltimaAtualizacao { get; set; } = DateTime.MinValue;
    public static bool ValidaUri(string? uri, IOptions<AppSettings> appSettings)
    {
        lock (ProdutoURIs)
        {
            var uris = ProdutoURIs;
            if (DateTime.Now > UltimaAtualizacao)
            {
                ProdutoURIs = EntityApi.GetListaUris("menphiscrm", appSettings.Value.ProdutoNET_ID);
                UltimaAtualizacao = DateTime.Now.AddMinutes(1);

                ProdutoURIs += ";" + appSettings.Value.DevURI;
                uris = ProdutoURIs;
            }

            return !string.IsNullOrEmpty(uri) && uris.ToUpper().Split(';').Contains(uri.ToUpper());
        }
    }


}
