using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToContainer("Cards");

            builder.HasPartitionKey(c => c.Catalog);

            builder.OwnsOne(
                o => o.Info,
                inf =>
                {
                    inf.ToJsonProperty("Info");
                });

            builder.OwnsMany(
                o => o.Back,
                back =>
                {
                    back.ToJsonProperty("Back");
                });

            builder.HasNoDiscriminator();
        }
    }
}
