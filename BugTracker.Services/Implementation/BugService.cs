using System.Collections.Generic;
using AutoMapper;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    public class BugService<TKey> : IBugService<TKey>
    {
        private readonly IUnitOfWork<TKey> _unitOfWork;
        private readonly IMapper _mapper;

        public BugService(IUnitOfWork<TKey> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Bug<TKey> GetBugById(TKey id)
        {
            return _mapper.Map<Bug<TKey>>(
                _unitOfWork.BugRepository.GetById(id));
        }

        public IEnumerable<Bug<TKey>> SearchBugs(string searchString)
        {
            return _mapper.Map<IEnumerable<Bug<TKey>>>(
                _unitOfWork.BugRepository.Search(searchString));
        }

        public IEnumerable<Bug<TKey>> GetBugsForProject(TKey projectId)
        {
            return _mapper.Map<IEnumerable<Bug<TKey>>>(
                _unitOfWork.BugRepository.GetBugsForProject(projectId));
        }

        public IEnumerable<Bug<TKey>> GetBugsForUser(TKey userId)
        {
            return _mapper.Map<IEnumerable<Bug<TKey>>>(
                _unitOfWork.BugRepository.GetBugsForUser(userId));
        }

        public void AssignBugToUser(Bug<TKey> bug, TKey userId)
        {
            bug.AssignToId = userId;
            _unitOfWork.BugRepository.Update(_mapper.Map<BugEntity<TKey>>(bug));
        }
    }
}
