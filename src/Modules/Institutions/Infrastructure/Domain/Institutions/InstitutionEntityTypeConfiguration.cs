using Institutions.Domain.Institutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class InstitutionEntityTypeConfiguration : IEntityTypeConfiguration<Institution>
{
    public void Configure(EntityTypeBuilder<Institution> builder)
    {
        builder.ToTable("institutions");

        builder.HasKey(x => x.Id);
        builder.Property(p => p.Id).HasConversion(c => c.Id, c => new InstitutionId(c));

        builder.Property<string>("_email").HasColumnName("email");
        builder.Property<string>("_password").HasColumnName("password");
        builder.Property<string>("_name").HasColumnName("name");
        builder.Property<string>("_code").HasColumnName("code");
        builder.Property<string>("_city").HasColumnName("city");
        builder.Property<string>("_address").HasColumnName("address");
        builder.Property<string>("_ownership").HasColumnName("ownership");
        builder.Property<DateTime>("_createdAt").HasColumnName("createdAt");
        builder.Property<DateTime>("_login").HasColumnName("login");
        builder.Property<string>("_type").HasColumnName("type");
    }
}