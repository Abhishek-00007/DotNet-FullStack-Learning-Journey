using System.Security.Cryptography;
using System.Text;

namespace SecureDatabaseApp.Services;

public class HmacService
{
    private readonly string _secret =
        "SuperSecretHMACKey";

    public string Generate(string data)
    {
        using HMACSHA256 hmac =
            new(Encoding.UTF8.GetBytes(_secret));

        byte[] hash =
            hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

        return Convert.ToBase64String(hash);
    }
}