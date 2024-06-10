using Companyx.Companyx.Studentx.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Companyx.Companyx.Studentx.Infrastructure.Configurations
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

            builder
                .Property(s => s.AssocitedAtUTC)
                .HasColumnName("associated_at_utc");

            builder.HasKey(x => new { x.UserId , x.SchoolId });

            builder.HasIndex(x => new { x.UserId, x.SchoolId });


            builder
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);

            builder
                .HasOne(u => u.School)
                .WithMany()
                .HasForeignKey(u => u.SchoolId);

            builder.Ignore(x => x.Id);
            builder.Ignore(x => x.RemovedAtUTC);
            builder.Ignore(x => x.CreatedAtUTC);
            builder.Ignore(x => x.UpdatedAtUTC);
        }
    }
}
