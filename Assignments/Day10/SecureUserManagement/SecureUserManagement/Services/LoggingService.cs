using Serilog;

namespace SecureUserManagement.Services
{
    public class LoggingService
    {
        public LoggingService()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/app.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void LogInformation(string message)
        {
            Log.Information(message);
        }

        public void LogError(string message)
        {
            Log.Error(message);
        }
    }
}