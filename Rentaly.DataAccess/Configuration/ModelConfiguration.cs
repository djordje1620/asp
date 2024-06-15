using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration
{
    public class ModelConfiguration : EntityConfiguration<Model>
    {
        protected override void ConfigureTableSpecifics(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.BrandId).IsRequired();

            builder.HasMany(x => x.Cars)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
