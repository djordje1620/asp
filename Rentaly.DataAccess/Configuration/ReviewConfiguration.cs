using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class ReviewConfiguration : EntityConfiguration<Review>
{
    protected override void ConfigureTableSpecifics(EntityTypeBuilder<Review> builder)
    {
        builder.Property(x => x.Comment).IsRequired();
        builder.Property(x => x.StarsRate).IsRequired();

        
    }
}
