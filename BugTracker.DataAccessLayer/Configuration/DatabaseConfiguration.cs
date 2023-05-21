using System;

namespace BugTracker.DataAccessLayer.Configuration;

internal class DatabaseConfiguration : ConfigurationBase
{
    public string GetDatabaseConnectionString()
    {
        var configuration =
            GetConfiguration().GetSection("DatabaseConnection");
        var server = configuration["DbServer"];
        var port = configuration["DbPort"];
        var user = configuration["DbUser"];
        var password = configuration["DbPassword"];
        var database = configuration["DbName"];

        Console.WriteLine($"Connection to db sever {server}");
        //return
        //    $"Server={server};Initial Catalog={database};User ID={user};Password={password};" +
        //    "MultipleActiveResultSets=true;Connect Timeout=30;Encrypt=False;" +
        //    "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        return
            $"Server=tcp:{server},{port};Initial Catalog={database};Persist Security Info=False;" + 
            $"User ID={user};Password={password};MultipleActiveResultSets=False;" + 
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
