using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration
{
    public class CarConfiguration : EntityConfiguration<Car>
    {
        protected override void ConfigureTableSpecifics(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Kilometars).IsRequired();
            builder.Property(x => x.ManufacturerYear).IsRequired();
            builder.Property(x => x.ModelId).IsRequired();
            builder.Property(x => x.TypeId).IsRequired();

            builder.HasMany(x => x.CarSpecifications)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.CarServices)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.Bookings)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.Prices)
                .WithOne(x => x.Car)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(x => x.Reviews)
               .WithOne(x => x.Car)
               .HasForeignKey(x => x.CarId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
        }
    }
}
