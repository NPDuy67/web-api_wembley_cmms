using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.Equipments
{
    public class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .UseHiLo("equipmenteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.EquipmentId).IsUnique();
            builder.Property(x => x.EquipmentId).HasMaxLength(50).IsRequired();

            builder
                .Property(c => c.Code)
                .HasMaxLength(60)
                .IsRequired(false);

            builder
               .Property(c => c.Name)
               .HasMaxLength(60)
               .IsRequired(false);

            builder
               .Property(c => c.UsedTime)
               .HasPrecision(30, 10)
               .IsRequired();

            builder.HasOne(x => x.MTBF).WithMany().IsRequired(false);
            builder.HasOne(x => x.MTTF).WithMany().IsRequired(false);
            builder.HasOne(x => x.OEE).WithMany().IsRequired(false);
            builder.HasMany(x => x.Materials).WithOne(x => x.Equipment).IsRequired();
        }
    }
}
