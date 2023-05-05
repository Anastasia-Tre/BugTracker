using System.Collections.Generic;
using AutoMapper;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation;

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
        var users = await _unitOfWork.TaskRepository.Search(searchString);
        return _mapper.Map<IEnumerable<Task<int>>>(users);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task<int>>>
        GetTasksForProject(
            int projectId)
    {
        var users =
            await _unitOfWork.TaskRepository.GetTasksForProject(projectId);
        return _mapper.Map<IEnumerable<Task<int>>>(users);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Task<int>>>
        GetTasksForUser(int userId)
    {
        var users = await _unitOfWork.TaskRepository.GetTasksForUser(userId);
        return _mapper.Map<IEnumerable<Task<int>>>(users);
    }

    public async System.Threading.Tasks.Task<Task<int>> AssignTaskToUser(
        int taskId, int userId)
    {
        var task = await _unitOfWork.TaskRepository.GetById(taskId);
        task.AssignToId = userId;
        _unitOfWork.TaskRepository.Update(task);
        await _unitOfWork.Save();
        return _mapper.Map<Task<int>>(task);
    }
}
