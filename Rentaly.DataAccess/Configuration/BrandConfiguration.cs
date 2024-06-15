using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;


namespace Rentaly.DataAccess.Configuration
{
    public class BrandConfiguration : EntityConfiguration<Brand>
    {
        protected override void ConfigureTableSpecifics(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Models)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
