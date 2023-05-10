using BugTracker.DataAccessLayer.Configuration;
using BugTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer;

public sealed class BugTrackerDbContext : DbContext
{
    private readonly string _connectionString;

    public BugTrackerDbContext(
        DbContextOptions<BugTrackerDbContext> options,
        string connectionString = null) : base(options)
    {
        _connectionString = connectionString ?? DbDefaultConnectionString;
        //Database.Migrate();
    }

    private static string DbDefaultConnectionString =>
        new DatabaseConfiguration()
            .GetDatabaseConnectionString();

    public DbSet<TaskEntity<int>> Tasks { get; set; }
    public DbSet<UserEntity<int>> Users { get; set; }
    public DbSet<ProjectEntity<int>> Projects { get; set; }
    public DbSet<UserProjectEntity<int>> UserProjects { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<UserEntity<int>>()
        //    .HasMany(s => s.Projects)
        //    .WithOne(s => s.Author)
        //    .HasForeignKey(e => e.AuthorId);

        modelBuilder.Entity<ProjectEntity<int>>()
                    .Navigation(p => p.Author)
                    .AutoInclude();

        modelBuilder.Entity<TaskEntity<int>>()
            .Navigation(p => p.Assigned)
            .AutoInclude();
        modelBuilder.Entity<TaskEntity<int>>()
            .Navigation(p => p.Project)
            .AutoInclude();
    }
}
