using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation
{
    public class EFBugRepository : EFRepository<BugEntity<int>>,
        IBugRepository<int>
    {
        public EFBugRepository(BugTrackerDbContext dbContext) : base(dbContext,
            dbContext.Bugs)
        {
        }

        public async Task<IEnumerable<BugEntity<int>>> Search(
            string searchString)
        {
            var result = await GetAll();
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

        public async Task<IEnumerable<BugEntity<int>>> GetBugsForProject(
            int projectId)
        {
            return (await GetAll())
                .Where(bug => bug.ProjectId.Equals(projectId))
                .OrderBy(bug => bug.Date);
        }

        public async Task<IEnumerable<BugEntity<int>>> GetBugsForUser(
            int userId)
        {
            return (await GetAll())
                .Where(bug => bug.AssignToId.Equals(userId))
                .OrderBy(bug => bug.Date);
        }
    }
}
