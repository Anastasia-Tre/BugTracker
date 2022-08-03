using System;
using System.Collections.Generic;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFBugRepository<TKey> : EFGenericRepository<BugEntity<TKey>, TKey>, IBugRepository<TKey>
    {
        public EFBugRepository(BugTrackerDbContext dbContext, DbSet<BugEntity<TKey>> dbSet) : base(dbContext, dbSet)
        {
        }

        public IEnumerable<BugEntity<TKey>> Search(string searchString = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BugEntity<TKey>> GetBugsForProject(TKey projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BugEntity<TKey>> GetBugsForUser(TKey userId)
        {
            throw new NotImplementedException();
        }
    }
}
