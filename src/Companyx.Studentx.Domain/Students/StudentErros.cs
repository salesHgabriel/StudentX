using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Students
{
    public static class StudentErros
    {
        public static readonly Error NotFound = new(
        "Student.StudentNotFound",
        "Student Not Found");
    }
}