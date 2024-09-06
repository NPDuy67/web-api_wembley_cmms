using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.MaterialInfors
{
    public class MaterialInforEntityTypeConfiguration : IEntityTypeConfiguration<MaterialInfor>
    {
        public void Configure(EntityTypeBuilder<MaterialInfor> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialinforeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialInforId).IsUnique();
            builder.Property(x => x.MaterialInforId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.MinimumQuantity)
               .HasPrecision(30, 10)
               .IsRequired();

            builder.HasMany(x => x.MaterialHistoryCards).WithOne().IsRequired();
            builder.HasMany(x => x.Materials).WithOne(x => x.MaterialInfor).IsRequired();
            builder.HasMany(x => x.MaterialRequests).WithOne(x => x.MaterialInfor).IsRequired();
        }
    }
}
