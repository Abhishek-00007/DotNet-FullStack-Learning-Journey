using System.Security.Cryptography;
using System.Text;

namespace SecureDatabaseApp.Services;

public class EncryptionService
{
    private readonly string _key =
        "12345678901234567890123456789012";

    public string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();

        aes.Key = Encoding.UTF8.GetBytes(_key);
        aes.GenerateIV();

        using MemoryStream ms = new();

        ms.Write(aes.IV, 0, aes.IV.Length);

        using CryptoStream cs =
            new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);

        using StreamWriter sw = new(cs);

        sw.Write(plainText);
        sw.Close();

        return Convert.ToBase64String(ms.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        byte[] fullCipher = Convert.FromBase64String(cipherText);

        using Aes aes = Aes.Create();

        byte[] iv = new byte[16];

        Array.Copy(fullCipher, 0, iv, 0, iv.Length);

        aes.Key = Encoding.UTF8.GetBytes(_key);
        aes.IV = iv;

        using MemoryStream ms =
            new(fullCipher, iv.Length, fullCipher.Length - iv.Length);

        using CryptoStream cs =
            new(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);

        using StreamReader sr = new(cs);

        return sr.ReadToEnd();
    }
}