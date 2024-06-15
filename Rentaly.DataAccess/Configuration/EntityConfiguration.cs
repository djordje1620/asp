using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Rentaly.Domain.Entities;
namespace Rentaly.DataAccess.Configuration
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
      where T : Entity
    {

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            ConfigureTableSpecifics(builder);
        }

        protected abstract void ConfigureTableSpecifics(EntityTypeBuilder<T> builder);
    }
}
