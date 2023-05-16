using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Microsoft.EntityFrameworkCore;
using TaskStatus = Bugify.Domain.AggregatesModel.TaskAggregate.TaskStatus;

namespace BugTracker.Infrastructure.Repositories.EFImplementation;

public class EFTaskRepository : EFRepository<TaskEntity<int>>,
    ITaskRepository<int>
{
    public EFTaskRepository(BugTrackerDbContext dbContext) : base(dbContext,
        dbContext.Tasks)
    {
    }

    public async System.Threading.Tasks.Task<IEnumerable<TaskEntity<int>>> Search(
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

        return await result.OrderByDescending(task => task.Created).ToListAsync();
    }

    public async System.Threading.Tasks.Task<IEnumerable<TaskEntity<int>>> GetTasksForProject(
        int projectId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.ProjectId.Equals(projectId))
            .ToListAsync();
    }

    public async System.Threading.Tasks.Task<IEnumerable<TaskEntity<int>>> GetTasksForUser(
        int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId))
            .ToListAsync();
    }

    /*
     * -- task in focus
       select top 1 * from Tasks
       where AssignedId = 1
       and status <= 2
       and ProjectId in (select Id from Projects
       where Status != 3)
       order by Deadline, Priority desc, Type desc
    */
    public async System.Threading.Tasks.Task<TaskEntity<int>> GetTaskInFocusForUser(
        int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId)
                           && (task.Status == TaskStatus.New ||
                               task.Status == TaskStatus.InProgress)
                           && task.Project.Status != ProjectStatus.Closed)
            .OrderBy(task => task.Deadline)
            .ThenByDescending(task => task.Priority)
            .ThenByDescending(task => task.Type)
            .FirstAsync();
    }

    /*
     * -- now or later
       select top 4 * from Tasks
       where AssignedId = 1
       and status <= 2
       and ProjectId in (select Id from Projects
       where Status != 3)
       order by Difficulty, Priority desc, Deadline, Type
     */
    public async System.Threading.Tasks.Task<IEnumerable<TaskEntity<int>>> GetTasksNowOrLaterForUser(
        int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId)
                           && (task.Status == TaskStatus.New ||
                               task.Status == TaskStatus.InProgress)
                           && task.Project.Status != ProjectStatus.Closed)
            .OrderBy(task => task.Difficulty)
            .ThenByDescending(task => task.Priority)
            .ThenBy(task => task.Deadline)
            .ThenBy(task => task.Type)
            .Take(4)
            .ToListAsync();
    }

    public async System.Threading.Tasks.Task<int> GetTotalTasksForUser(int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId)
                           && task.Project.Status != ProjectStatus.Closed)
            .CountAsync();
    }

    public async System.Threading.Tasks.Task<int> GetCompleteTasksForUser(int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId)
                           && (task.Status == TaskStatus.InTesting ||
                               task.Status == TaskStatus.Closed)
                           && task.Project.Status != ProjectStatus.Closed)
            .CountAsync();
    }

    public async System.Threading.Tasks.Task<int> GetUncompleteTasksForUser(int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId)
                           && (task.Status == TaskStatus.New ||
                               task.Status == TaskStatus.InProgress)
                           && task.Project.Status != ProjectStatus.Closed)
            .CountAsync();
    }

    public async System.Threading.Tasks.Task<int> GetOverdueTasksForUser(int userId)
    {
        return await _entities.AsQueryable()
            .Where(task => task.AssignedId.Equals(userId)
                           && (task.Status == TaskStatus.New ||
                               task.Status == TaskStatus.InProgress ||
                               task.Status == TaskStatus.InTesting)
                           && task.Project.Status != ProjectStatus.Closed)
            .Where(task => task.Deadline < DateTime.Now)
            .CountAsync();
    }
}
