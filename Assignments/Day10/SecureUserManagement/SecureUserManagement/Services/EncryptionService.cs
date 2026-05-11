using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Services
{
    public class EncryptionService
    {
        private readonly byte[] Key;
        private readonly byte[] IV;

        public EncryptionService()
        {
            using (Aes aes = Aes.Create())
            {
                Key = aes.Key;
                IV = aes.IV;
            }
        }

        public string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor =
                aes.CreateEncryptor(aes.Key, aes.IV);

            using MemoryStream ms = new();

            using CryptoStream cs =
                new(ms, encryptor, CryptoStreamMode.Write);

            using (StreamWriter sw = new(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform decryptor =
                aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream ms =
                new(Convert.FromBase64String(cipherText));

            using CryptoStream cs =
                new(ms, decryptor, CryptoStreamMode.Read);

            using StreamReader sr = new(cs);

            return sr.ReadToEnd();
        }
    }
}