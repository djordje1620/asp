using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class CarAccessoryConfiguration : EntityConfiguration<CarAccessory>
{
    protected override void ConfigureTableSpecifics(EntityTypeBuilder<CarAccessory> builder)
    {
        builder.Property(x => x.Name).IsRequired();

        builder.HasMany(x => x.Bookings)
            .WithOne(x => x.CarAccessory)
            .HasForeignKey(x => x.CarAccessoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
