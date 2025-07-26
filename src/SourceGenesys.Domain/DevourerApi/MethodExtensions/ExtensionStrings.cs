namespace MenphisSI;

/// <summary>
/// 31-08-2016
/// http://www.c-sharpcorner.com/blogs/extension-method-in-c-sharp3
/// </summary>
public static partial class ExtensionMethodStrings
{



    public static string substring(this string text, in int startIndex, in int length = 0) =>
        text.Length ==0 ? "" : (length == 0 || length > $"{text}".Length ?
        $"{text}"[startIndex..] :
        $"{text}".Substring(startIndex, length));

    //public static string DecodeBase64(this string base64) =>
    //    Encoding.UTF8.GetString(Convert.FromBase64String(base64));
    public static string replace(this string text, string oldValue, string newValue)
        => $"{text}".Replace($"{oldValue}", $"{newValue}");

    public static int Length(this string? text) => string.IsNullOrEmpty(text) ? 0 : text.trim().Length;

    public static bool IsEquals(this string? text, string? value)
        =>
            $"{text}".Equals($"{value}");

    public static string trim(this string? text) => string.IsNullOrEmpty(text) ? "" : text?.Trim() ?? string.Empty;
    public static bool endsWith(this string? text, string? value) => $"{text}".EndsWith(value ?? string.Empty);
    public static string toUpper(this string? value) => $"{value}".ToUpper();

    public static int indexOf(this string? campo, string? value,
        StringComparison comparisonType = StringComparison.Ordinal) =>
        campo is null ? -1 : campo.IndexOf(value ?? "", comparisonType);


    public static bool IsNão(this bool value) => !value;
    public static bool IsEmptyIDNumber(this int valueID) => valueID <= 0;

    private static string[] StartColors { get; } =
        [
            "#430943", // 0 lilás
            "#99ff99", // 1
            "#ff99dd", // 2
            "#0000e6", // 3
            "#b32d00", // 4
            "#b300b3", // 5
            "#663300", // 6 marrom
            "#666666", // 7 cinza
            "#b39800", // 8 dourado
            "#a6a6a6"  // 9 prateado
        ];

    private static string[] EndColors { get; } =
    [
        "#ff6680", // 0 - rosá
        "#267326", // 1 - army green
        "#ff1a1a", // 2 - vermelho
        "#668cff", // 3 - tom de azul do mar'
        "#cc5200", // 4 - abóbora
        "#e600ac", // 5 - rosá pink
        "#003300", // 6 - verde musgo
        "#d2a679", // 7 - castanho claro
        "#ffff00", // 8 -  amarelo queimado
        "#ff6666", // 9 - vermelho cintilante
    ];

    public static string ColorFirstLastName(this string text)
    {
        const string PAllNumbers = "0123456789";

        if (PAllNumbers.Contains(text[..1]))
        {
            var nPos = Convert.ToInt32(text[..1]); // NASA
            if (nPos >= 0 && nPos < StartColors.Length)
                return StartColors[nPos];
        }

        if (text.Length > 1)
            if (PAllNumbers.Contains(text[^1].ToString()))
            {
                var nPos = Convert.ToInt32(text[^1].ToString()); // NASA
                if (nPos >= 0 && nPos < EndColors.Length)
                    return EndColors[nPos];
            }

        var colors = new[]
        {
            "#0040ff", //A
            "#ff1a8c", //B
            "#00ff00", //C
            "#ff0000", //D
            "#ff80b3", //E
            "#ffc2b3", //F
            "#8000ff", //G
            "#b3d9ff", //H
            "#999900", //I
            "#73e600", //J
            "#0000e6", //K
            "#ff1aff", //L
            "#0066cc", //M
            "#33ffd6", //N
            "#77ff33", //O
            "#66d9ff", //P
            "#003300", //Q
            "#0000b3", //R
            "#00ffff", //S
            "#52527a", //T
            "#40bf80", //U
            "#b800e6", //V
            "#668cff", //W
            "#ff8c1a", //X
            "#53c68c", //Y
            "#e600e6", //Z
        };
        if (text.IsEmpty()) return "#000";
        var pos = Encoding.ASCII.GetBytes(text.Substring(text.Length - 1, 1).ToUpper())[0] - 65;
        return pos >= 0 && pos < colors.Length ? colors[pos] : "#E0E0E0";
    }

    public static string ImgFirstLastName(this string text)
    {
        if (text.IsEmpty()) return string.Empty;

        try
        {
            var sp = text.Split(' ');
            return sp.Length == 1 ? text[..1] : sp[0][..1] + sp[^1][..1];
        }
        catch
        {
            // Ignore
        }

        return text[..1];
    }


    public static bool IsEmpty(this decimal value) => value == 0m;

    public static bool IsEmpty(this string? text) =>
        string.IsNullOrEmpty(text) || text.trim().Equals(string.Empty); // 22-12-2016

    public static string GetHashCode2(this string str)
    {
        if (str is null) return "0";
        unchecked
        {
            var hash1 = (5381 << 16) + 5381;
            var hash2 = hash1;

            for (var i = 0; i < str.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return (hash1 + (hash2 * 1566083941)).ToString();
        }
    } 

    public static bool NotIsEmpty(this string? text) =>
        !(string.IsNullOrEmpty(text) || text.trim().Equals(string.Empty)); // 05-05-2017 15:00
     

    public static bool ContemUpper(this string text, string palavra) => !string.IsNullOrEmpty(text) &&
                                                                        !string.IsNullOrEmpty(palavra) &&
                                                                        text.ToUpper().IndexOf(palavra.ToUpper(),
                                                                            StringComparison.Ordinal) != -1;

    public static bool NãoContemUpper(this string? text, string palavra) => string.IsNullOrEmpty(text) ||
                                                                            text.toUpper().IndexOf(palavra.ToUpper(),
                                                                                StringComparison.Ordinal) == -1;

    public static bool NotEquals(this string text, string value) => !text.Equals(value); 

 
    public static bool Contem(this string text, string palavra) => !string.IsNullOrEmpty(text) &&
                                                                   text.Length > palavra.Length && text.IndexOf(palavra,
                                                                       StringComparison.Ordinal) != -1;

 
 

    public static string ComTraço(this string? text) => text.IsEmpty() ? string.Empty : $" - {text}";

    public static string FirstName(this string text) => text?.Split(' ')[0] ?? string.Empty;

    public static string LastName(this string text)
    {
        if (text.IsEmpty()) return "";
        var split = text.Split(' ');
        return split[^1];
    }
 
    public static string FixAbc(this string? text) =>
       ((text.trim().Length <= 1 || "abcdefghijklmnopqrstuvwxyz\u00FA\u00ED\u00F3\u00E1\u00E0\u00E9".IndexOf(text.trim()[..1], StringComparison.Ordinal) == -1) ?
           text :
           ($"{text}".IndexOf('@') == -1 ? text.trim()[..1].ToUpper() + text.trim()[1..]
               : text))!;

    public static string FixAbc(this string text, int maxWidth)
    {
        if (string.IsNullOrEmpty(text)) return string.Empty;
        var ret = text.Trim();
        ret =
           (ret.Length <= 1 || "abcdefghijklmnopqrstuvwxyz\u00FA\u00ED\u00F3\u00E1\u00E0\u00E9".IndexOf(ret[..1], StringComparison.Ordinal) == -1) ?
           ret :
           (ret.IndexOf('@') == -1 ? ret[..1].ToUpper() + ret[1..]
            : text);
        return (ret.Length > maxWidth) ? ret[..maxWidth] : ret;
    }

}

