using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation;

public class EFTaskRepository : EFRepository<TaskEntity<int>>,
    ITaskRepository<int>
{
    public EFTaskRepository(BugTrackerDbContext dbContext) : base(dbContext,
        dbContext.Tasks)
    {
    }

    public async Task<IEnumerable<TaskEntity<int>>> Search(
        string searchString)
    {
        var result = _entities.AsQueryable();
        var isSearchStringEmpty = string.IsNullOrEmpty(searchString);

        if (!isSearchStringEmpty)
        {
            searchString = searchString.ToLower();
            result = await Task.Run(() => result.Where(task =>
                task.Name.ToLower().Contains(searchString)
                || task.Description.Contains(searchString)));
        }

        return await result.ToListAsync();
    }

    public async Task<IEnumerable<TaskEntity<int>>> GetTasksForProject(
        int projectId)
    {
        return await _entities
            .Where(task => task.ProjectId.Equals(projectId))
            .ToListAsync();
    }

    public async Task<IEnumerable<TaskEntity<int>>> GetTasksForUser(
        int userId)
    {
        return await _entities
            .Where(task => task.AssignedId.Equals(userId))
            .ToListAsync();
    }
}
