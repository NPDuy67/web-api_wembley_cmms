using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.MaterialInforAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.MaterialInfors
{
    public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("materialeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaterialId).IsUnique();
            builder.Property(x => x.MaterialId).HasMaxLength(50).IsRequired();
        }
    }
}
