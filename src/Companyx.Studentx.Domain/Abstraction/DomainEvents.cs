using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Companyx.Companyx.Studentx.Domain.Abstraction
{
    public static class DomainEvents
    {
        private static IServiceScopeFactory _serviceScopeFactory = null!;

        public static void Initialize(IServiceProvider serviceProvider) 
        {
            _serviceScopeFactory =  serviceProvider.GetRequiredService<IServiceScopeFactory>();
        }

        public static async Task Raise<T>(T args) where T : IDomainEvent
        {
            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            await mediator.Publish<T>(args);
        }
    }
}
