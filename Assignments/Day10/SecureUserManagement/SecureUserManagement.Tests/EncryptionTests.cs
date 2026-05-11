using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    public class EncryptionTests
    {
        [Fact]
        public void EncryptDecrypt_ReturnsOriginalText()
        {
            EncryptionService service =
                new EncryptionService();

            string text = "Hello";

            string encrypted =
                service.Encrypt(text);

            string decrypted =
                service.Decrypt(encrypted);

            Assert.Equal(text, decrypted);
        }
    }
}