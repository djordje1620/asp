using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class CarServiceConfiguration : EntityConfiguration<CarService>
{
    protected override void ConfigureTableSpecifics(EntityTypeBuilder<CarService> builder)
    {
        builder.Property(x => x.ServiceName).IsRequired();

       
    }
}
