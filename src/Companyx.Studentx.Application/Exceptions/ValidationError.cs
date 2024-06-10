namespace Companyx.Companyx.Studentx.Application.Exceptions
{
    public sealed record ValidationError(string PropertyName, string ErrorMessage);
}
