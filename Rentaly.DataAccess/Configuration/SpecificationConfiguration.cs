using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration
{
    public class SpecificationConfiguration : EntityConfiguration<Specification>
    {
        protected override void ConfigureTableSpecifics(EntityTypeBuilder<Specification> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Cars)
                .WithOne(x => x.Specification)
                .HasForeignKey(x => x.SpecificationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
