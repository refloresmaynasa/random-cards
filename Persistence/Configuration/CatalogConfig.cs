using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CatalogConfig : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(150);

            builder.Property(p => p.IsPublic)
                .IsRequired();

            builder.Property(p => p.UserId)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.UserName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.UserEmail)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
