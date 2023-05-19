using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Domain.AggregatesModel.UserAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace Bugify.Infrastructure.Mapper;

public static class MapperConfig
{
    public static IServiceCollection SetMapperConfig(
        this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
            cfg.CreateMap<Task<int>, TaskEntity<int>>().ReverseMap());
        services.AddAutoMapper(cfg =>
            cfg.CreateMap<Project<int>, ProjectEntity<int>>()
                .ReverseMap());
        services.AddAutoMapper(cfg =>
            cfg.CreateMap<User<int>, UserEntity<int>>().ReverseMap());

        return services;
    }
}
