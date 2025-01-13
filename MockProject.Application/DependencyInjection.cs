using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MockProject.Application.Behaviours;

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
            });

            services.AddValidatorsFromAssembly(applicationAssembly);
            
            return services;
        }
    }
}
