using BugTracker.Services.Abstraction;
using BugTracker.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Services
{
    public static class DependenciesServices
    {
        public static IServiceCollection SetServices<TKey>(
            this IServiceCollection services)
        {
            services.AddScoped<IBugService<TKey>, BugService<TKey>>();
            services.AddScoped<IUserService<TKey>, UserService<TKey>>();
            services.AddScoped<IProjectService<TKey>, ProjectService<TKey>>();

            return services;
        }
    }
}
