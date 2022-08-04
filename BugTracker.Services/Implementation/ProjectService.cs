using System.Collections.Generic;
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

        public Project<int> GetProjectById(int id)
        {
            return _mapper.Map<Project<int>>(
                _unitOfWork.BugRepository.GetById(id));
        }

        public IEnumerable<Project<int>> SearchProjects(string searchString)
        {
            return _mapper.Map<IEnumerable<Project<int>>>(
                _unitOfWork.BugRepository.Search(searchString));
        }
    }
}
