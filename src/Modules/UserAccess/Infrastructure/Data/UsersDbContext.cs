using Microsoft.EntityFrameworkCore;
using UserAccess.Domain.User;

namespace UserAccess.Infrastructure.Data;

public sealed class UsersDbContext : DbContext
{
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Student> Students { get; set; }

    private readonly string _connectionString = string.Empty;

    public UsersDbContext(string connectionString) => _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
            .UseSnakeCaseNamingConvention();
    }
}