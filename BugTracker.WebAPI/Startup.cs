using System.Reflection;
using BugTracker.DataAccessLayer;
using BugTracker.Services;
using BugTracker.Services.Mapper;
using BugTracker.WebAPI.Behaviors;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BugTracker.WebAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost",
                builder =>
                {
                    builder.WithOrigins(
                            "http://localhost:3000",
                            "http://localhost:8080",
                            "https://bugifyclient.azurewebsites.net",
                            "https://bugify-client.azurewebsites.net"
                            )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        services.SetEFDataDependencies();
        services.SetMapperConfig();
        services.SetServices();

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddSingleton(typeof(IPipelineBehavior<,>),
            typeof(LoggingBehavior<,>));

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                    { Title = "BugTracker.WebAPI", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        ILogger<Startup> logger)
    {
        app.UseCors("AllowLocalhost");

        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
            c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "BugTracker.WebAPI v1"));

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                logger.LogInformation(context.Request.GetDisplayUrl());
                await context.Response.WriteAsync("BugTracker");
            });
        });
    }
}
