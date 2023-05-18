using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Domain.AggregatesModel.UserAggregate;
using Bugify.Domain.SeedWork;
using BugTracker.Infrastructure.Repositories.EFImplementation;
using BugTracker.Infrastructure.Services;
using BugTracker.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Infrastructure;

public static class DependenciesEFData
{
    public static IServiceCollection SetEFDataDependencies(
        this IServiceCollection services)
    {
        services.AddDbContext<BugTrackerDbContext>();
        services.AddScoped<ITaskRepository<int>, EFTaskRepository>();
        services.AddScoped<IUserRepository<int>, EFUserRepository>();
        services.AddScoped<IProjectRepository<int>, EFProjectRepository>();
        services
            .AddScoped<IUserProjectRepository<int>,
                EFUserProjectRepository>();
        services.AddScoped<IUnitOfWork<int>, EFUnitOfWork>();

        return services;
    }

    public static IServiceCollection SetServices(
        this IServiceCollection services)
    {
        services.AddScoped<ITaskService<int>, TaskService>();
        services.AddScoped<IUserService<int>, UserService>();
        services.AddScoped<IProjectService<int>, ProjectService>();

        return services;
    }
}
