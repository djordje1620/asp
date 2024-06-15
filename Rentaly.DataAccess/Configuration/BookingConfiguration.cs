using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class BookingConfiguration : EntityConfiguration<Booking>
{
    protected override void ConfigureTableSpecifics(EntityTypeBuilder<Booking> builder)
    {
        builder.Property(s => s.TotalPrice).HasPrecision(18, 2).IsRequired();


    }
}
