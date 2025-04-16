using System.IO;
using System.Security.Cryptography;

#nullable enable
namespace MenphisSI;

public static class HookCryptoV1
{
    // IMPRIMIR
    private static string EncryptionKey =>
        Crypto.Decrypt("k99te08L4sn+00vqc9RuHGC6ihvm52ortGfeYyx/pZ24wOPyOxnd//qoSTQ8u/SN71e+3R5+GGeYMfpEXwGjDKUpICXPoEXnPAdkfWsPow82368PWj/qvj/OB8oZmJOo");

    // "fgdg@lr23oi2mqwpdmkfdmafuhwelrkj20r92jrpwefjwm";  
    //we can change the code converstion key as per our requirement    

    internal static string Encrypt(string encryptString)
    {
        try
        {
            var clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using var encryptor = Aes.Create();
#pragma warning disable SYSLIB0041 // Type or member is obsolete
            var pdb = new Rfc2898DeriveBytes(EncryptionKey, [
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                ]);
#pragma warning restore SYSLIB0041 // Type or member is obsolete
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
            }

            encryptString = Convert.ToBase64String(ms.ToArray());

            return encryptString;
        }
        catch { return ""; }
    }
    internal static string Decrypt(string cipherText)
    {
        try
        {
            //string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement, but the decryption key should be same as encryption key    
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using var encryptor = Aes.Create();
#pragma warning disable SYSLIB0041 // Type or member is obsolete
            var pdb = new Rfc2898DeriveBytes(EncryptionKey, [
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                ]);
#pragma warning restore SYSLIB0041 // Type or member is obsolete
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();
            }
            cipherText = Encoding.Unicode.GetString(ms.ToArray());

            return cipherText;
        }
        catch { return ""; }
    }
}
