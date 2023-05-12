using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction;

public interface ITaskRepository<TKey> : IRepository<TaskEntity<TKey>, TKey>
{
    public Task<IEnumerable<TaskEntity<TKey>>> Search(string searchString);

    public Task<IEnumerable<TaskEntity<TKey>>> GetTasksForProject(
        TKey projectId);

    public Task<IEnumerable<TaskEntity<TKey>>> GetTasksForUser(TKey userId);

    public Task<TaskEntity<TKey>> GetTaskInFocusForUser(TKey userId);

    public Task<IEnumerable<TaskEntity<TKey>>> GetTasksNowOrLaterForUser(
        TKey userId);

    public Task<int> GetTotalTasksForUser(int userId);

    public Task<int> GetCompleteTasksForUser(int userId);

    public Task<int> GetUncompleteTasksForUser(int userId);

    public Task<int> GetOverdueTasksForUser(int userId);
}
