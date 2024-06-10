using Companyx.Companyx.Studentx.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Companyx.Companyx.Studentx.Infrastructure.Configurations
{
    public static class SetupEntityBaseConfiguration
    {
        public static EntityTypeBuilder<TEntity> Configure<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : EntityRoot
        {

            builder.HasKey(entity => entity.Id);

            builder.HasIndex(entity => entity.Id);

            builder
                .Property(s => s.CreatedAtUTC)
                .HasColumnName("created_at_utc");

            builder
                .Property(s => s.UpdatedAtUTC)
                .HasColumnName("updated_at_utc");

            builder
                .Property(s => s.RemovedAtUTC)
                .HasColumnName("removed_at_utc");

            builder.HasQueryFilter(entity => !entity.RemovedAtUTC.HasValue);

            return builder;
        }
    }
}
