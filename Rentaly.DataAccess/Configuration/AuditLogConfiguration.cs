using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;

namespace Rentaly.DataAccess.Configuration;
public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.Property(x => x.Identity).IsRequired().HasMaxLength(50);
        builder.Property(x => x.UseCaseName).IsRequired().HasMaxLength(50);

        builder.HasIndex(x => x.UserId);
        builder.HasIndex(x => x.Identity);
        builder.HasIndex(x => x.ExecutionDateTime);
        builder.HasIndex(x => x.UseCaseName);

    }
}