using System;

namespace BugTracker.DataAccessLayer.Configuration
{
    internal class DatabaseConfiguration : ConfigurationBase
    {
        public string GetDatabaseConnectionString()
        {
            var configuration = GetConfiguration().GetSection("DatabaseConnection");
            var server = configuration["DbServer"];
            var user = configuration["DbUser"];
            var password = configuration["DbPassword"];
            var database = configuration["DbName"];
            
            Console.WriteLine("In DatabaseConfiguration   " + server + ":" + user + ":" + password);
            return
                $"Server={server};Initial Catalog={database};User ID={user};Password={password};" +
                "MultipleActiveResultSets=true;Connect Timeout=30;Encrypt=False;" + 
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
