using BugTracker.DataAccessLayer.Configuration;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataAccessLayer.UnitOfWork.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.DataAccessLayer
{
    public static class DependenciesEFData
    {
        private static string DbConnectionString => new DatabaseConfiguration()
            .GetDatabaseConnectionString();

        public static IServiceCollection SetEFDataDependencies(
            this IServiceCollection services, string connectionString = null)
        {
            services.AddDbContext<BugTrackerDbContext>(options =>
                options.UseSqlServer(connectionString ?? DbConnectionString));
            //services.AddScoped<BugTrackerDbContext>();
            services.AddScoped<IBugRepository<int>, EFBugRepository>();
            services.AddScoped<IUserRepository<int>, EFUserRepository>();
            services.AddScoped<IProjectRepository<int>, EFProjectRepository>();
            services
                .AddScoped<IUserProjectRepository<int>,
                    EFUserProjectRepository>();
            services.AddScoped<IUnitOfWork<int>, EFUnitOfWork>();

            return services;
        }
    }
}
