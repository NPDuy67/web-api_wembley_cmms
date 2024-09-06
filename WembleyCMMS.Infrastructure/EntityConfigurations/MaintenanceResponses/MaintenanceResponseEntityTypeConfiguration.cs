using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.MaintenanceResponses
{
    public class MaintenanceResponseEntityTypeConfiguration : IEntityTypeConfiguration<MaintenanceResponse>
    {
        public void Configure(EntityTypeBuilder<MaintenanceResponse> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("maintenanceresponseeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaintenanceResponseId).IsUnique();
            builder.Property(x => x.MaintenanceResponseId).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Cause).WithMany(c => c.MaintenanceResponses);
            builder.HasMany(x => x.Correction).WithMany(c => c.MaintenanceResponses);

            builder.HasMany(x => x.Materials).WithOne().IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Request).WithMany().IsRequired();
            builder.HasOne(x => x.ResponsiblePerson).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.EquipmentClass).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Equipment).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.InspectionReports).WithOne().IsRequired(false);
        }
    }
}
