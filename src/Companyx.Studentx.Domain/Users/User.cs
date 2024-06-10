using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Ratings;
using Companyx.Companyx.Studentx.Domain.Schools;
using Companyx.Companyx.Studentx.Domain.Users.Events;
using Microsoft.AspNetCore.Identity;

namespace Companyx.Companyx.Studentx.Domain.Users
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
        }

        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            UserName = name;
            Email = email;
        }

        public DateTime? RemovedAtUTC { get; private set; }

        public static Result<User> Create(string name, string email, Guid? schoolId)
        {
            var user = new User(name, email);

            return user;
        }
        public static void AssociateAsStudent(Guid id, Guid? schoolId) => DomainEvents.Raise(new UserCreatedDomainEvent(id, schoolId)).Wait();
        public void Remove() => RemovedAtUTC = DateTime.UtcNow;

        public void RemoveStudent(Guid userId, Guid schoolId)
        {
            Remove();

            DomainEvents.Raise(new UserRemovedDomainEvent(userId, schoolId)).Wait();
        }

        public void SetName(string name) => UserName = name;

        public virtual ICollection<School> Schools { get; set; } = [];

        public virtual ICollection<Rating> Ratings { get; } = [];
    }
}