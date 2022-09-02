using System;
using BugTracker.DataAccessLayer;
using BugTracker.DataAccessLayer.Identity;
using BugTracker.Services.Abstraction;
using BugTracker.Services.Implementation;
using BugTracker.Services.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BugTracker.Services
{
    public static class DependenciesServices
    {
        public static IServiceCollection SetServices(
            this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BugTrackerDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options => {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddScoped<IBugService<int>, BugService>();
            services.AddScoped<IUserService<int>, UserService>();
            services.AddScoped<IProjectService<int>, ProjectService>();

            services.AddAutoMapper(typeof(BugTrackerMapper));
            return services;
        }
    }
}
