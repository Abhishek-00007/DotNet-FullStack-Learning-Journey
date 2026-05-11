using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public void Register_User_ReturnsTrue()
        {
            AuthenticationService auth =
                new AuthenticationService();

            bool result =
                auth.Register("test", "123");

            Assert.True(result);
        }

        [Fact]
        public void Authenticate_ValidUser_ReturnsTrue()
        {
            AuthenticationService auth =
                new AuthenticationService();

            auth.Register("test", "123");

            bool result =
                auth.Authenticate("test", "123");

            Assert.True(result);
        }
    }
}