using Microsoft.Extensions.Configuration;

namespace BugTracker.DataAccessLayer.Configuration
{
    internal class DatabaseConfiguration : ConfigurationBase
    {
        private string DbConnectionKey = "DefaultConnection";
        public string GetDatabaseConnectionString()
        {
            return GetConfiguration().GetConnectionString(DbConnectionKey);
        }
    }
}
