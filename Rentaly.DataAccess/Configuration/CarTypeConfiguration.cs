using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration
{
    public class CarTypeConfiguration : EntityConfiguration<CarType>
    {
        protected override void ConfigureTableSpecifics(EntityTypeBuilder<CarType> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Cars)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
