using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.MaterialInfors
{
    public class MaterialHistoryCardEntityTypeConfiguration : IEntityTypeConfiguration<MaterialHistoryCard>
    {
        public void Configure(EntityTypeBuilder<MaterialHistoryCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialhistorycardeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialHistoryCardId).IsUnique();
            builder.Property(x => x.MaterialHistoryCardId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.Before)
               .HasPrecision(30, 10)
               .IsRequired();
            builder
               .Property(c => c.Input)
               .HasPrecision(30, 10)
               .IsRequired();
            builder
               .Property(c => c.Output)
               .HasPrecision(30, 10)
               .IsRequired();

            builder
               .Property(c => c.After)
               .HasPrecision(30, 10)
               .IsRequired();
        }
    }
}
