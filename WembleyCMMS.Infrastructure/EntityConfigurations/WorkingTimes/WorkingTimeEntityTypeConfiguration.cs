using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WembleyCMMS.Domain.AggregateModels.WorkingTimeAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.WorkingTimes
{
    public class WorkingTimeEntityTypeConfiguration : IEntityTypeConfiguration<WorkingTime>
    {
        public void Configure(EntityTypeBuilder<WorkingTime> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("workingtimeeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.WorkingTimeId).IsUnique();
            builder.Property(x => x.WorkingTimeId).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.ResponsiblePerson).WithMany().IsRequired();
            builder.HasOne(x => x.Equipment).WithMany().IsRequired();
        }
    }
}
