using BugTracker.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer
{
    public sealed class BugTrackerDbContext<TKey> : DbContext
    {
        public BugTrackerDbContext()
        {
            Database.EnsureCreated();
        }

        // ????? TKey ??????
        public DbSet<BugEntity<TKey>> Bugs { get; set; }
        public DbSet<UserEntity<TKey>> Users { get; set; }
        public DbSet<ProjectEntity<TKey>> Projects { get; set; }
        public DbSet<UserProjectEntity<TKey>> UserProjects { get; set; }
    }
}
