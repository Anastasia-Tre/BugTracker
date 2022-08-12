using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    public class ProjectService : IProjectService<int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;

        public ProjectService(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Project<int>> GetProjectById(int id)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(id);
            return _mapper.Map<Project<int>>(project);
        }

        public async Task<IEnumerable<Project<int>>> SearchProjects(
            string searchString)
        {
            var projects = await _unitOfWork.ProjectRepository.Search(searchString);
            return _mapper.Map<IEnumerable<Project<int>>>(projects);
        }
    }
}
