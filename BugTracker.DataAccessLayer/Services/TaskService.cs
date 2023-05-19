using System.Collections.Generic;
using AutoMapper;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Domain.SeedWork;

namespace Bugify.Infrastructure.Services;

public class TaskService : ITaskService<int>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<int> _unitOfWork;

    public TaskService(IUnitOfWork<int> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async System.Threading.Tasks.Task<Task<int>> GetTaskById(int id)
    {
        var task = await _unitOfWork.TaskRepository.GetById(id);
        return _mapper.Map<Task<int>>(task);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task<int>>>
        SearchTasks(string searchString)
    {
        var tasks = await _unitOfWork.TaskRepository.Search(searchString);
        return _mapper.Map<IEnumerable<Task<int>>>(tasks);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task<int>>>
        GetTasksForProject(
            int projectId)
    {
        var tasks =
            await _unitOfWork.TaskRepository.GetTasksForProject(projectId);
        return _mapper.Map<IEnumerable<Task<int>>>(tasks);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task<int>>>
        GetTasksForUser(int userId)
    {
        var tasks = await _unitOfWork.TaskRepository.GetTasksForUser(userId);
        return _mapper.Map<IEnumerable<Task<int>>>(tasks);
    }

    public async System.Threading.Tasks.Task<Task<int>> AssignTaskToUser(
        int taskId, int userId)
    {
        var task = await _unitOfWork.TaskRepository.GetById(taskId);
        task.AssignedId = userId;
        _unitOfWork.TaskRepository.Update(task);
        await _unitOfWork.Save();
        return _mapper.Map<Task<int>>(task);
    }

    public async System.Threading.Tasks.Task<Task<int>> CreateTask(
        Task<int> task)
    {
        var mappedTask = _mapper.Map<TaskEntity<int>>(task);
        await _unitOfWork.TaskRepository.Create(mappedTask);
        await _unitOfWork.Save();
        return task;
    }

    public async System.Threading.Tasks.Task<Task<int>> UpdateTask(
        Task<int> task)
    {
        var mappedTask = _mapper.Map<TaskEntity<int>>(task);
        _unitOfWork.TaskRepository.Update(mappedTask);
        await _unitOfWork.Save();
        return task;
    }

    public async System.Threading.Tasks.Task<Task<int>> DeleteTask(
        Task<int> task)
    {
        var mappedTask = _mapper.Map<TaskEntity<int>>(task);
        _unitOfWork.TaskRepository.Delete(mappedTask);
        await _unitOfWork.Save();
        return task;
    }

    public async System.Threading.Tasks.Task<Task<int>> GetTaskInFocusForUser(
        int userId)
    {
        var tasks =
            await _unitOfWork.TaskRepository.GetTaskInFocusForUser(userId);
        return _mapper.Map<Task<int>>(tasks);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task<int>>>
        GetTasksNowOrLaterForUser(int userId)
    {
        var tasks =
            await _unitOfWork.TaskRepository.GetTasksNowOrLaterForUser(userId);
        return _mapper.Map<IEnumerable<Task<int>>>(tasks);
    }

    public System.Threading.Tasks.Task<int> GetTotalTasksForUser(int userId)
    {
        return _unitOfWork.TaskRepository.GetTotalTasksForUser(userId);
    }

    public System.Threading.Tasks.Task<int> GetCompleteTasksForUser(int userId)
    {
        return _unitOfWork.TaskRepository.GetCompleteTasksForUser(userId);
    }

    public System.Threading.Tasks.Task<int> GetUncompleteTasksForUser(int userId)
    {
        return _unitOfWork.TaskRepository.GetUncompleteTasksForUser(userId);
    }

    public System.Threading.Tasks.Task<int> GetOverdueTasksForUser(int userId)
    {
        return _unitOfWork.TaskRepository.GetOverdueTasksForUser(userId);
    }
}
