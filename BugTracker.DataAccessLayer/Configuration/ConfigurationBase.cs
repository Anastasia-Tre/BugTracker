using System;
using Microsoft.Extensions.Configuration;

namespace BugTracker.DataAccessLayer.Configuration
{
    public abstract class ConfigurationBase
    {
        protected IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    true, true)
                .Build();
        }

        protected void RaiseValueNotFoundException(string configurationKey)
        {
            throw new Exception(
                $"appsettings key ({configurationKey}) could not be found.");
        }
    }
}
