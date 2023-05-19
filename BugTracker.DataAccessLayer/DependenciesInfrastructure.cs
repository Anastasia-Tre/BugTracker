﻿using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Domain.AggregatesModel.UserAggregate;
using Bugify.Domain.SeedWork;
using Bugify.Infrastructure.Repositories.EFImplementation;
using Bugify.Infrastructure.Services;
using Bugify.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Bugify.Infrastructure;

public static class DependenciesInfrastructure
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
