using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataModel;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Services.Mapper
{
    internal static class MapperConfig
    {
        public static IServiceCollection SetMapperConfig<TKey>(
            this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
                cfg.CreateMap<Bug<TKey>, BugEntity<TKey>>().ReverseMap());
            services.AddAutoMapper(cfg =>
                cfg.CreateMap<Project<TKey>, ProjectEntity<TKey>>()
                    .ReverseMap());
            services.AddAutoMapper(cfg =>
                cfg.CreateMap<User<TKey>, UserEntity<TKey>>().ReverseMap());

            return services;
        }
    }
}
