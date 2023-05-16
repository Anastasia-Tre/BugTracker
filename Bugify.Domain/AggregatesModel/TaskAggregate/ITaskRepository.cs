using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.TaskAggregate;

public interface ITaskRepository<TKey> : IRepository<TaskEntity<TKey>, TKey>
{
    public System.Threading.Tasks.Task<IEnumerable<TaskEntity<TKey>>> Search(string searchString);

    public System.Threading.Tasks.Task<IEnumerable<TaskEntity<TKey>>> GetTasksForProject(
        TKey projectId);

    public System.Threading.Tasks.Task<IEnumerable<TaskEntity<TKey>>> GetTasksForUser(TKey userId);

    public System.Threading.Tasks.Task<TaskEntity<TKey>> GetTaskInFocusForUser(TKey userId);

    public System.Threading.Tasks.Task<IEnumerable<TaskEntity<TKey>>> GetTasksNowOrLaterForUser(
        TKey userId);

    public System.Threading.Tasks.Task<int> GetTotalTasksForUser(int userId);

    public System.Threading.Tasks.Task<int> GetCompleteTasksForUser(int userId);

    public System.Threading.Tasks.Task<int> GetUncompleteTasksForUser(int userId);

    public System.Threading.Tasks.Task<int> GetOverdueTasksForUser(int userId);
}
