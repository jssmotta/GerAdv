using System.Text;

namespace MenphisSI;

public static class InfraExtensions
{
    public static string dbo(this string TabelaNome, MsiSqlConnection? oCnn) => TabelaNome.Contains("_sp_") ?
    $"{oCnn?.UseDbo ?? "dbo"}.{TabelaNome} " :
    $" [{oCnn?.UseDbo ?? "dbo"}].[{TabelaNome}] ";

    public static string DecodeBase642(this string base64) => Encoding.UTF8.GetString(Convert.FromBase64String(base64));

    public static string Base64Encode2(this string plainText) => Convert.ToBase64String(Encoding.ASCII.GetBytes(plainText));

}
