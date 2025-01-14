using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MockProject.Application.Behaviours;
using MockProject.Domain;

namespace MockProject.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(Application.DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(applicationAssembly);

                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
                configuration.AddOpenBehavior(typeof(UnitOfWorkBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(applicationAssembly);

            return services;
        }
    }
}
