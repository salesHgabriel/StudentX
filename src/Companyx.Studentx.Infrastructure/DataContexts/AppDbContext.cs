using Companyx.Companyx.Studentx.Application.Exceptions;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Courses;
using Companyx.Companyx.Studentx.Domain.Ratings;
using Companyx.Companyx.Studentx.Domain.Schools;
using Companyx.Companyx.Studentx.Domain.Students;
using Companyx.Companyx.Studentx.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace Companyx.Companyx.Studentx.Infrastructure.DataContexts
{
    public sealed class AppDbContext : IdentityDbContext<User, Role, Guid>, IUnitOfWork
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        private readonly IPublisher _publisher;

        public AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }



        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                //TODO: maybe add outbox pattern
                await PublishDomainEventsAsync();

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("Concurrency exception ocurred.", ex);
            }

        }

        private async Task PublishDomainEventsAsync()
        {

            var domainEvents = ChangeTracker
                .Entries<EntityRoot>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.GetDomainEvents();

                    entity.ClearDomainEvents();

                    return domainEvents;
                }).ToList();

            foreach (var domainEvent in domainEvents) await _publisher.Publish(domainEvent);
        }

    }
}
