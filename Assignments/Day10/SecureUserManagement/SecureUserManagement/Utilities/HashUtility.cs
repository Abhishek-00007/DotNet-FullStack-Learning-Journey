using System.Security.Cryptography;
using System.Text;

namespace SecureUserManagement.Utilities
{
    public static class HashUtility
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(
                    Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();

                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}