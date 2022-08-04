using BugTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer
{
    public sealed class BugTrackerDbContext : DbContext
    {
        public BugTrackerDbContext()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<BugEntity<int>> Bugs { get; set; }
        public DbSet<UserEntity<int>> Users { get; set; }
        public DbSet<ProjectEntity<int>> Projects { get; set; }
        public DbSet<UserProjectEntity<int>> UserProjects { get; set; }
    }
}
