using BugTracker.Services.Abstraction;
using BugTracker.Services.Implementation;
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
