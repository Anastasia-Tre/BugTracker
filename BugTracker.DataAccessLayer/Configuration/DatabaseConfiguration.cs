using System;
using Microsoft.Extensions.Configuration;

namespace BugTracker.DataAccessLayer.Configuration
{
    internal class DatabaseConfiguration : ConfigurationBase
    {
        private readonly string DbConnectionKey = "DefaultConnection";

        public string GetDatabaseConnectionString()
        {
            return GetConfiguration().GetConnectionString(DbConnectionKey);
        }

        public string GetConnectionStringFromConfiguration()
        {
            var configuration = GetConfiguration();
            var server = configuration["DbServer"] ?? "localhost";
            var port = configuration["DbPort"] ?? "1433";
            var user = configuration["DbUser"] ?? "SA";
            var password = configuration["DbPassword"] ?? "Pa$w0rd2022";
            var database = configuration["DbName"] ?? "BugTrackerDb";

            //Console.WriteLine("In DatabaseConfiguration   " + configuration);
            Console.WriteLine("In DatabaseConfiguration   " + server + ":" + port + ":" + user + ":" + password);
            return
                $"Server={server}, {port};Initial Catalog={database};Persist Security Info=True;User ID={user};Password={password}";
        }
    }
}
