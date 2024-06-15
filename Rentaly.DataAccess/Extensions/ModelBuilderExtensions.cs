using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyCustomConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentalyDbContext).Assembly);
            modelBuilder.Entity<CarSpecification>().HasKey(x => new { x.CarId, x.SpecificationId });
            modelBuilder.Entity<BookingCarAccessories>().HasKey(x => new { x.BookingId, x.CarAccessoryId });
            modelBuilder.Entity<RoleUseCases>().HasKey(x => new { x.RoleId, x.UseCaseId });
        }
    }
}
