using SecureDatabaseApp.Models;

namespace SecureDatabaseApp.Services;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto model);

    Task<string?> LoginAsync(LoginDto model);
}