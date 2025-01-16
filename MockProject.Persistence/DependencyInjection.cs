using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MockProject.Domain;
using MockProject.Domain.Repositories;
using MockProject.Persistence.DataAccess;
using MockProject.Persistence.Repositories;

namespace MockProject.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string databaseConnectionString)
        {
            var applicationAssembly = typeof(Persistence.DependencyInjection).Assembly;

            services.AddDbContext<MockProjectDbContext>(options => options.UseSqlServer(databaseConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
