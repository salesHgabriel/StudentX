namespace Companyx.Companyx.Studentx.Application.Users.GetAllStudents
{
    public record GetAllStudentResponse(Guid UserId, string Nome, string Email, DateTime AssociatedAtUTC);
}
