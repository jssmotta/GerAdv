
#nullable enable
namespace MenphisSI;

// https://www.c-sharpcorner.com/article/encrypt-and-decrypt-user-password-in-sql-server-db-using-c-sharp-winform-application/
public static partial class Crypto
{

    public static string SenhaTlete => Decrypt("dAUl/OUMKJ0PGkUyeSCp1zj5nNHNJvKgCNLck/VpsdE=");
    /// <summary>
    /// 09-04-2019 20:33
    /// </summary>
    public static string SenhaBDIbr => Decrypt(
                 "2vY0ZG0UgP/gY5fcm8Dvb4z9RXGX4EV5xEDKUXZxxvA="
        );

    /// <summary>
    /// 13-04-2019
    /// </summary>
    public static string SenhaSuporteRede => Decrypt("osrKf8HwP9So6qGui1KlRXy01xfiWJouEnRikLTemIk=");

    /// <summary>
    /// Hahahahah se fudeu - 09-05-2019
    /// </summary>
    public static string SenhaSuporteWindows => Decrypt("5OHAsVottUO7VSkKtPIdxA==");

    public static bool CheckSenhaAdminOS(string senha) => senha.Equals(Decrypt("RhSKsZ0wcjgcpDE5KHGmnA==")); // 200900

    // IMPRIMIR
    public static string SenhaEMailRelatorio => "Pocoto#123";// Decrypt("Zno+n+COEVje2i1NcXZnIAGouX8Uw2ypaL1hRdXTjzE="); // "Pocoto#123"

   
    public static string SenhaFtp => Decrypt("jgm62ueDIO0vYIrTwxKRANaAqPcKvvOuWFD6TpxoUDk=");

    // Alice1234
    // ReSharper disable once InconsistentNaming
    public static string SenhaBDsSAN => Decrypt("VQW+oc32V47ZR5DocGUqzjosxbq1pNAMTyTyUJMFigI=");
}

