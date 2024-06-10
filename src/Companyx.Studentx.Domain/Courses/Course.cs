using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Courses.Events;
using Companyx.Companyx.Studentx.Domain.Ratings;

namespace Companyx.Companyx.Studentx.Domain.Courses
{
    public class Course : EntityRoot
    {
        public Course()
        {
        }

        public Course(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public virtual ICollection<Rating> Ratings { get; } = null!;

        public void SetName(string name) => Name = name;

        public void SetDescription(string desc) => Description = desc;

        public static Course Create(string name, string desc)
        {
            var course = new Course(name, desc);

            course.RaiseDomainEvent(new CreatedCourseDomainEvent(course.Id));

            return course;
        }
    }
}