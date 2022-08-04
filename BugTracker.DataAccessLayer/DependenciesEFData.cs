using BugTracker.DataAccessLayer.Repositories.Abstraction;
using BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.DataAccessLayer
{
    public static class DependenciesEFData
    {
        public static IServiceCollection SetEFDataDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<BugTrackerDbContext>();
            services.AddScoped<IBugRepository<int>, EFBugRepository>();
            services.AddScoped<IUserRepository<int>, EFUserRepository>();
            services.AddScoped<IProjectRepository<int>, EFProjectRepository>();
            services.AddScoped<IUserProjectRepository<int>, EFUserProjectRepository>();
            
            return services;
        }
    }
}
