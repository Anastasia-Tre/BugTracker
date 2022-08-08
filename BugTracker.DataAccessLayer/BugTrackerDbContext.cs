using BugTracker.DataAccessLayer.Configuration;
using BugTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer
{
    public sealed class BugTrackerDbContext : DbContext
    {
        private string _connectionString;
        private static string DbDefaultConnectionString => new DatabaseConfiguration()
            .GetDatabaseConnectionString();

        public DbSet<BugEntity<int>> Bugs { get; set; }
        public DbSet<UserEntity<int>> Users { get; set; }
        public DbSet<ProjectEntity<int>> Projects { get; set; }
        public DbSet<UserProjectEntity<int>> UserProjects { get; set; }

        public BugTrackerDbContext(string connectionString = null) : base()
        {
            _connectionString = connectionString ?? DbDefaultConnectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString);
            //.UseExceptionProcessor();
        }
    }
}
