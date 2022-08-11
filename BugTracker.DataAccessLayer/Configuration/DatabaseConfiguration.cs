using System;
using System.Net;
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

        //public static string DockerHostMachineIpAddress => Dns.GetHostAddresses(new Uri("http://docker.for.win.localhost").Host)[0].ToString();

        public string GetConnectionStringFromConfiguration()
        {
            var configuration = GetConfiguration();
            var server = configuration["DbServer"] ?? "localhost";
            var port = configuration["DbPort"] ?? "1450";
            var user = configuration["DbUser"] ?? "SA";
            var password = configuration["DbPassword"] ?? "Pa__w0rd2022";
            var database = configuration["DbName"] ?? "BugTrackerDb";
            
            Console.WriteLine("In DatabaseConfiguration   " + server + ":" + port + ":" + user + ":" + password);
            Console.WriteLine("DockerHostMachineIpAddress   ");
            //return $"Data Source={server}, {port};Initial Catalog={database};User ID={user};Password={password};MultipleActiveResultSets=true";
            return $"Server=mssql;Initial Catalog={database};User ID={user};Password={password};MultipleActiveResultSets=true";
            //return
            //$"Server={DockerHostMachineIpAddress}\\SQL2019;Database={database};User Id={user};Password={password};";
        }
    }
}
