using Microsoft.EntityFrameworkCore;
using Students.Application.Data;
using Students.Domain.Students;

namespace Students.Infrastructure.Data;

public sealed class StudentsDbContext : DbContext, IStudentsDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    private readonly string _connectionString = string.Empty;

    public StudentsDbContext(string connectionString) => _connectionString = connectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString))
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(p => p.RegistrationNumber).HasColumnName("registrationNumber");
            entity.Property(p => p.CreatedAt).HasColumnName("createdAt");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(p => p.OwnerId);
            entity.Property(p => p.OwnerId).HasColumnName("ownerId");
            entity.Property(p => p.DiscountType).HasColumnName("discountType");
            entity.Property(p => p.CreatedAt).HasColumnName("createdAt");
        });
    }
}