using System.Collections.Generic;
using AutoMapper;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation;

public class ProjectService : IProjectService<int>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<int> _unitOfWork;

    public ProjectService(IUnitOfWork<int> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async System.Threading.Tasks.Task<Project<int>>
        GetProjectById(int id)
    {
        var project = await _unitOfWork.ProjectRepository.GetById(id);
        return _mapper.Map<Project<int>>(project);
    }

    public async System.Threading.Tasks.Task<IEnumerable<Project<int>>>
        SearchProjects(
            string searchString)
    {
        var projects =
            await _unitOfWork.ProjectRepository.Search(searchString);
        return _mapper.Map<IEnumerable<Project<int>>>(projects);
    }

    public async System.Threading.Tasks.Task<Project<int>>
        CreateProject(Project<int> project)
    {
        var mappedProject = _mapper.Map<ProjectEntity<int>>(project);
        await _unitOfWork.ProjectRepository.Create(mappedProject);
        await _unitOfWork.Save();
        return project;
    }

    public async System.Threading.Tasks.Task<Project<int>> UpdateProject(Project<int> project)
    {
        var mappedProject = _mapper.Map<ProjectEntity<int>>(project);
        _unitOfWork.ProjectRepository.Update(mappedProject);
        await _unitOfWork.Save();
        return project;
    }
}
