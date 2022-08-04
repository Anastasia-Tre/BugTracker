using System.Collections.Generic;
using AutoMapper;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    internal class ProjectService<TKey> : IProjectService<TKey>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<TKey> _unitOfWork;

        public ProjectService(IUnitOfWork<TKey> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Project<TKey> GetBugById(TKey id)
        {
            return _mapper.Map<Project<TKey>>(
                _unitOfWork.BugRepository.GetById(id));
        }

        public IEnumerable<Project<TKey>> SearchBugs(string searchString)
        {
            return _mapper.Map<IEnumerable<Project<TKey>>>(
                _unitOfWork.BugRepository.Search(searchString));
        }
    }
}
