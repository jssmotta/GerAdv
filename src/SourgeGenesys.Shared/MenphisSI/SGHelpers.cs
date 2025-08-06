using System.Text;

namespace MenphisSI;

public static class SGHelpers
{
    public const string PSenhaReset = "111111";
    public const string PSenhaResetHash = "1255531832";

    internal static bool IsEquals(this string? text, string? value)
    =>
        $"{text}".Equals($"{value}");
    public static bool IsSenhaFraca(string senha, string nomeOperador)
    {
        if (senha.Length < 8 ||
            senha.IsEquals(PSenhaReset) ||
            senha.ContemUpper("Advocati") ||
            senha.ContemUpper("Menphis") ||
            senha.ContemUpper("12345") ||
            senha.ContemUpper(nomeOperador.FirstName()) ||
            senha.ContemUpper(nomeOperador.LastName()) ||
            senha.ContemUpper(nomeOperador)
           ) return true;
        var nTem3Iguais = 0;
        for (var x = 0; x < senha.Length - 1; x++)
        {
            if (senha.Substring(x, length: 1).Equals(senha.Substring(startIndex: x + 1, length: 1)))
            {
                nTem3Iguais++;
                if (nTem3Iguais == 2) return true;
                continue;
            }

            nTem3Iguais = 0;
        }

        return false;
    }

    internal static string FirstName(this string text) => text?.Split(' ')[0] ?? string.Empty;

    internal static string LastName(this string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        var split = text.Split(' ');
        return split[^1];
    }

    internal static bool ContemUpper(this string text, string palavra) => !string.IsNullOrEmpty(text) &&
                                                                     !string.IsNullOrEmpty(palavra) &&
                                                                     text.ToUpper().IndexOf(palavra.ToUpper(),
                                                                         StringComparison.Ordinal) != -1;

    public static string DecodeBase64(this string base64) =>
        Encoding.UTF8.GetString(Convert.FromBase64String(base64));

    public static string Base64Encode(this string plainText) =>
        Convert.ToBase64String(Encoding.ASCII.GetBytes(plainText));

    public static string Sql(this string columnName, string value)
    {
        if (string.IsNullOrEmpty(value)) return $" {columnName} IS NULL ";
        return $" [{columnName}] = @{columnName} ";
    }

    public static string Sql(this string columnName, bool value)
    {
        
        return $" [{columnName}] = {(value?"1":"0")} ";
    }
}