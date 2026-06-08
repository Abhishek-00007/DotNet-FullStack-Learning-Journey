using SecureDatabaseApp.Models;

namespace SecureDatabaseApp.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByIdAsync(int id);

    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);

    Task SaveChangesAsync();
}