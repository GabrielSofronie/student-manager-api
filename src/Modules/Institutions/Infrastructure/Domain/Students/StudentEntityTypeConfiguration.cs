using Institutions.Domain.Institutions;
using Institutions.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder.HasKey(x => x.Id);
        builder.Property(p => p.Id).HasConversion(c => c.Id, c => new StudentId(c));

        builder
            // .Property<InstitutionId>("_institutionId")
            .Property(p => p.InstitutionId)
            .HasColumnName("institutionId")
            .HasConversion(c => c.Id, c => new InstitutionId(c));
        builder.Property<string>("_email").HasColumnName("email");
        builder.Property<string>("_password").HasColumnName("password");
        // builder.Property<string>("_name").HasColumnName("name");
        builder.Property(p => p.RegistrationNumber)
        // builder.Property<RegistrationNumber>("_registrationNumber")
            .HasColumnName("registrationNumber")
            .HasConversion(
                v => v.ToString(),
                v => RegistrationNumber.From(v)
            );
        builder.Property<DateTime>("_createdAt").HasColumnName("createdAt");
        builder.Property<DateTime>("_login").HasColumnName("login");
        builder.Property<string>("_faculty").HasColumnName("faculty");
        // builder.Property<string>("_code").HasColumnName("code");
        // builder
        //     // .Property<byte>("_discountType")
        //     .Property(p => p.DiscountType)
        //     .HasColumnName("discountType");
    }
}