using Companyx.Companyx.Studentx.Domain.Schools;
using Companyx.Companyx.Studentx.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Companyx.Companyx.Studentx.Infrastructure.Configurations
{
    public class SchoolEntityConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("schools");

            builder.Configure();

            builder
                .HasMany(e => e.Users)
                .WithMany(e => e.Schools)
                .UsingEntity<Student>();


            builder.HasData(new School("school admin"));

        }
    }
}