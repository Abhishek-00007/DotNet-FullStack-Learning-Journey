using Microsoft.EntityFrameworkCore;
using SecureDatabaseApp.Models;

namespace SecureDatabaseApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
}