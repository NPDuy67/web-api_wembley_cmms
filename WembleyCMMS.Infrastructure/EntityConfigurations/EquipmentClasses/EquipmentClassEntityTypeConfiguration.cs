using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.EquipmentClassAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.EquipmentClasses
{
    public class EquipmentClassEntityTypeConfiguration : IEntityTypeConfiguration<EquipmentClass>
    {
        public void Configure(EntityTypeBuilder<EquipmentClass> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .UseHiLo("equipmentclasseq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.EquipmentClassId).IsUnique();
            builder.Property(x => x.EquipmentClassId).HasMaxLength(50).IsRequired();

            builder
               .Property(c => c.Name)
               .HasMaxLength(60)
               .IsRequired(false);

            builder.HasMany(c => c.Equipments).WithOne(c => c.EquipmentClass).IsRequired();
        }
    }
}
