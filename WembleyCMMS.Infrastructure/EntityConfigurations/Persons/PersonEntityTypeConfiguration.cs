using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WembleyCMMS.Domain.AggregateModels.PersonAggregate;

namespace WembleyCMMS.Infrastructure.EntityConfigurations.Persons
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .UseHiLo("personeq", ApplicationDbContext.DEFAULT_SCHEMA);

            builder.HasIndex(x => x.PersonId).IsUnique();
            builder.Property(x => x.PersonId).HasMaxLength(50).IsRequired();
        }
    }
}
