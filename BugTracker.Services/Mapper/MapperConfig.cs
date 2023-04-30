using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataModel;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Services.Mapper;

public static class MapperConfig
{
    public static IServiceCollection SetMapperConfig(
        this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
            cfg.CreateMap<Bug<int>, BugEntity<int>>().ReverseMap());
        services.AddAutoMapper(cfg =>
            cfg.CreateMap<Project<int>, ProjectEntity<int>>()
                .ReverseMap());
        services.AddAutoMapper(cfg =>
            cfg.CreateMap<User<int>, UserEntity<int>>().ReverseMap());

        return services;
    }
}
