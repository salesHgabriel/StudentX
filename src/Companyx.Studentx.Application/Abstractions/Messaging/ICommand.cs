using Companyx.Companyx.Studentx.Domain.Abstraction;
using MediatR;


namespace Companyx.Companyx.Studentx.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }
    public interface IBaseCommand
    {
    }

}
