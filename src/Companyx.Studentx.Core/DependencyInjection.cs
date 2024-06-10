using Companyx.Companyx.Studentx.Application.Abstractions.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Companyx.Companyx.Studentx.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectCore(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;

        }
    }
}
