using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.CauseAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.Causes
{
    public class CauseEntityTypeConfiguration : IEntityTypeConfiguration<Cause>
    {
        public void Configure(EntityTypeBuilder<Cause> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("causeseq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.CauseId).IsUnique();
            builder.Property(x => x.CauseId).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.EquipmentClass).WithMany().IsRequired();
        }
    }
}
