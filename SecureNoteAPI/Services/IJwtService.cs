using SecureNoteAPI.Models;

namespace SecureNoteAPI.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}