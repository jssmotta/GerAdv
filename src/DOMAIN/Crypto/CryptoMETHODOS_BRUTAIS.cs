#nullable enable
namespace MenphisSI;

/// <summary>
/// 31-08-2016
/// http://www.c-sharpcorner.com/blogs/extension-method-in-c-sharp3
/// </summary>
public static partial class ExtensionMethodStringsCrypti
{
    public static string Encrypt(this string valueX) => HookCryptoV1.Encrypt(valueX);
    public static string Decrypt(this string valueX) => HookCryptoV1.Decrypt(valueX);
}

