﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.MaintenanceRequestAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.MaintenanceRequests
{
    public class MaintenanceRequestEntityTypeConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
    {
        public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("maintenancerequesteq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.MaintenanceRequestId).IsUnique();
            builder.Property(x => x.MaintenanceRequestId).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.EquipmentClass).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Requester).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Reviewer).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Equipment).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ResponsiblePerson).WithMany().IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Problem).HasMaxLength(500).IsRequired();
        }
    }
}
