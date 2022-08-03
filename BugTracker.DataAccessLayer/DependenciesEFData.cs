using BugTracker.DataAccessLayer.Repositories.Abstraction;
using BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.DataAccessLayer
{
    public static class DependenciesEFData
    {
        public static IServiceCollection SetEFDataDependencies<TKey>(
            this IServiceCollection services)
        {
            services.AddScoped<BugTrackerDbContext<TKey>>();
            services.AddScoped<IBugRepository<TKey>, EFBugRepository<TKey>>();
            services.AddScoped<IUserRepository<TKey>, EFUserRepository<TKey>>();
            services.AddScoped<IProjectRepository<TKey>, EFProjectRepository<TKey>>();
            services.AddScoped<IUserProjectRepository<TKey>, EFUserProjectRepository<TKey>>();
            
            return services;
        }
    }
}
