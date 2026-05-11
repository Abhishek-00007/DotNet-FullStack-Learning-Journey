using SecureUserManagement.Services;

namespace SecureUserManagement.Tests
{
    public class LoggingTests
    {
        [Fact]
        public void LogInformation_DoesNotThrowException()
        {
            LoggingService logger =
                new LoggingService();

            logger.LogInformation("Test log");

            Assert.True(true);
        }
    }
}
