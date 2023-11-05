using Institutions.Application.Data;
using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace Institutions.Infrastructure;

public sealed class InstitutionsContext : DbContext, IInstitutionsDbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Institution> Institutions { get; set; }

    private readonly string _connectionString = string.Empty;

    public InstitutionsContext() { }

    public InstitutionsContext(DbContextOptions options) : base(options) { }

    public InstitutionsContext(string connectionString) => _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new StudentEntityTypeConfiguration())
            .ApplyConfiguration(new InstitutionEntityTypeConfiguration())
        ;
    }
}
