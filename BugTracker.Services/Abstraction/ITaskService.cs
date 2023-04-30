using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction;

public interface ITaskService<TKey>
{
    // public Task<TKey> CreateTask();
    public System.Threading.Tasks.Task<Task<TKey>> GetTaskById(TKey id);

    public System.Threading.Tasks.Task<IEnumerable<Task<TKey>>>
        SearchTasks(string searchString = "");

    public System.Threading.Tasks.Task<IEnumerable<Task<TKey>>>
        GetTasksForProject(TKey projectId);

    public System.Threading.Tasks.Task<IEnumerable<Task<TKey>>> GetTasksForUser(
        TKey userId);

    public System.Threading.Tasks.Task<Task<TKey>> AssignTaskToUser(TKey taskId,
        TKey userId);
}
