using System;
using BugTracker.DataAccessLayer.Configuration;
using BugTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer
{
    public sealed class BugTrackerDbContext : DbContext
    {
        private readonly string _connectionString;

        public BugTrackerDbContext(
            DbContextOptions<BugTrackerDbContext> options,
            string connectionString = null) : base(options)
        {
            _connectionString = connectionString ?? DbDefaultConnectionString;
            Console.WriteLine("In BugTackerDbContext" + _connectionString);
            Database.EnsureCreated();
        }

        private static string DbDefaultConnectionString =>
            new DatabaseConfiguration()
                .GetDatabaseConnectionString();

        public DbSet<BugEntity<int>> Bugs { get; set; }
        public DbSet<UserEntity<int>> Users { get; set; }
        public DbSet<ProjectEntity<int>> Projects { get; set; }
        public DbSet<UserProjectEntity<int>> UserProjects { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString);
        }
    }
}
