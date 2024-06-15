using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class PriceConfiguration : EntityConfiguration<Price>
{
    protected override void ConfigureTableSpecifics(EntityTypeBuilder<Price> builder)
    {
        builder.Property(s => s.PricePerDay).HasPrecision(18, 2).IsRequired();
    }
}
