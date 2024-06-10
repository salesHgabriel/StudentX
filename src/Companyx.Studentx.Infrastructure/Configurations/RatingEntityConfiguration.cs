using Companyx.Companyx.Studentx.Domain.Ratings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Companyx.Companyx.Studentx.Infrastructure.Configurations
{
    public class RatingEntityConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("ratings");

            builder.Configure();

            builder.HasIndex(b => new { b.UserId, b.CourseId });


            builder
                .Property(x => x.Start)
                .HasMaxLength(5)
                .IsRequired();

            builder
                .Property(x => x.Comment)
                .HasMaxLength(256);


            builder
                .HasOne(s => s.Course)
                .WithMany(s => s.Ratings)
                .HasForeignKey(s => s.CourseId);

            builder
                   .HasOne(s => s.User)
                   .WithMany(s => s.Ratings)
                   .HasForeignKey(s => s.UserId);
        }
    }
}
