using SecureUserManagement.Services;

namespace SecureUserManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AuthenticationService authService =
                new AuthenticationService();

            EncryptionService encryptionService =
                new EncryptionService();

            LoggingService logger =
                new LoggingService();

            try
            {
                bool registered =
                    authService.Register("admin", "password123");

                Console.WriteLine(
                    $"Registration Successful: {registered}");

                bool login =
                    authService.Authenticate(
                        "admin",
                        "password123");

                Console.WriteLine(
                    $"Login Successful: {login}");

                string encrypted =
                    encryptionService.Encrypt("Sensitive Data");

                Console.WriteLine($"Encrypted: {encrypted}");

                string decrypted =
                    encryptionService.Decrypt(encrypted);

                Console.WriteLine($"Decrypted: {decrypted}");

                logger.LogInformation(
                    "Application executed successfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                Console.WriteLine(
                    "An unexpected error occurred.");
            }
        }
    }
}