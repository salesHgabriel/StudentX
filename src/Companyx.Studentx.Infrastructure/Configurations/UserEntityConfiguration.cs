using Companyx.Companyx.Studentx.Domain.Students;
using Companyx.Companyx.Studentx.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Companyx.Companyx.Studentx.Infrastructure.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
            .Property(s => s.RemovedAtUTC);

            builder
                .HasQueryFilter(entity => !entity.RemovedAtUTC.HasValue);

            builder
                .HasMany(e => e.Schools)
                .WithMany(e => e.Users)
                .UsingEntity<Student>();
        }
    }
}