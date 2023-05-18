using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Domain.AggregatesModel.UserAggregate;
using BugTracker.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Services;

public static class DependenciesServices
{
    public static IServiceCollection SetServices(
        this IServiceCollection services)
    {
        services.AddScoped<ITaskService<int>, TaskService>();
        services.AddScoped<IUserService<int>, UserService>();
        services.AddScoped<IProjectService<int>, ProjectService>();

        return services;
    }
}
