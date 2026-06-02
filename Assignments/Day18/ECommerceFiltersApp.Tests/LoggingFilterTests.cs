using Xunit;
using Moq;
using ECommerceFiltersApp.Services;

namespace ECommerceFiltersApp.Tests
{
    public class LoggingFilterTests
    {
        [Fact]
        public void Log_Service_Should_Be_Called()
        {
            var mock = new Mock<ILoggingService>();

            mock.Object.Log("Test");

            mock.Verify(
                x => x.Log(It.IsAny<string>()),
                Times.Once);
        }
    }
}