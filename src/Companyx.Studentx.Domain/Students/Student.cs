using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Schools;
using Companyx.Companyx.Studentx.Domain.Students.Events;
using Companyx.Companyx.Studentx.Domain.Users;

namespace Companyx.Companyx.Studentx.Domain.Students
{
    public class Student : EntityRoot
    {
        public Student()
        {
            
        }
        public Student(Guid userId, Guid schooId)
        {
            UserId = userId;
            SchoolId = schooId;
            AssocitedAtUTC = DateTime.UtcNow;
        }

        public Guid UserId { get; private set; }
        public virtual User User { get; } = null!;
        public Guid SchoolId { get; private set; }
        public virtual School School { get;  } = null!;
        public DateTime AssocitedAtUTC { get; private set; }

        public static Student Create(Guid userId, Guid schoolId)
        {
            var course = new Student(userId, schoolId);

            course.RaiseDomainEvent(new AssocietatedUserWithSchoolDomainEvent(course.UserId, course.SchoolId));

            return course;
        }
    }
}