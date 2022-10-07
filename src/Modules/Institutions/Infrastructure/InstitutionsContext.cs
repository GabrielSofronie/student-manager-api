using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace Institutions.Infrastructure;

public sealed class InstitutionsContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Institution> Institutions { get; set; }

    public InstitutionsContext() { }

    public InstitutionsContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new StudentEntityTypeConfiguration())
            .ApplyConfiguration(new InstitutionEntityTypeConfiguration())
        ;
    }
}
