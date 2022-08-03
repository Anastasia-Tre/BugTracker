using System.Collections.Generic;
using System.Linq;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFBugRepository<TKey> : EFRepository<BugEntity<TKey>, TKey>, IBugRepository<TKey>
    {
        public EFBugRepository(BugTrackerDbContext<TKey> dbContext) : base(dbContext, dbContext.Bugs)
        {
        }

        public IEnumerable<BugEntity<TKey>> Search(string searchString = "")
        {
            var result = GetAll();
            var isSearchStringEmpty = string.IsNullOrEmpty(searchString);

            if (!isSearchStringEmpty)
            {
                searchString = searchString.ToLower();
                result = result.Where(bug =>
                    bug.Name.ToLower().Contains(searchString)
                    || bug.Description.Contains(searchString));
            }

            return result.OrderBy(bug => bug.Date);
        }

        public IEnumerable<BugEntity<TKey>> GetBugsForProject(TKey projectId)
        {
            return GetAll()
                .Where(bug => bug.ProjectId.Equals(projectId))
                .OrderBy(bug => bug.Date);
        }

        public IEnumerable<BugEntity<TKey>> GetBugsForUser(TKey userId)
        {
            return GetAll()
                .Where(bug => bug.AssignToId.Equals(userId))
                .OrderBy(bug => bug.Date);
        }
    }
}
