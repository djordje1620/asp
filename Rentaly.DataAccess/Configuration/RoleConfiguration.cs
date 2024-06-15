using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class RoleConfiguration : EntityConfiguration<Role>
{
    protected override void ConfigureTableSpecifics(EntityTypeBuilder<Role> builder)
    {
        builder.Property(x => x.Name).IsRequired();

        builder.HasMany(x => x.Users)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .IsRequired();

        builder.HasMany(x => x.RoleUseCases)
            .WithOne(x => x.Role)
            .HasForeignKey(x => x.RoleId)
            .IsRequired();
    }
}
