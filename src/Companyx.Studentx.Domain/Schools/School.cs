using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Users;

namespace Companyx.Companyx.Studentx.Domain.Schools
{
    public class School : EntityRoot
    {
        public School()
        {
            
        }
        public School(string name)
        {
            Name = name;
        }
        public string Name { get; private set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; } = [];

        public static School Create(string name)
        {
            var school = new School(name);

            school.RaiseDomainEvent(new CreatedSchoolDomainEvent(school.Id));
            
            return school;
        }

    }
}
