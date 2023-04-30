using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation;

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
        var result = _entities.AsQueryable();
        var isSearchStringEmpty = string.IsNullOrEmpty(searchString);

        if (!isSearchStringEmpty)
        {
            searchString = searchString.ToLower();
            result = await Task.Run(() => result.Where(bug =>
                bug.Name.ToLower().Contains(searchString)
                || bug.Description.Contains(searchString)));
        }

        return await result.ToListAsync();
    }

    public async Task<IEnumerable<BugEntity<int>>> GetBugsForProject(
        int projectId)
    {
        return await _entities
            .Where(bug => bug.ProjectId.Equals(projectId))
            .ToListAsync();
    }

    public async Task<IEnumerable<BugEntity<int>>> GetBugsForUser(
        int userId)
    {
        return await _entities
            .Where(bug => bug.AssignToId.Equals(userId))
            .ToListAsync();
    }
}
