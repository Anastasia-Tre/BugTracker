using System.Collections.Generic;
using AutoMapper;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    public class BugService : IBugService<int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;

        public BugService(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Bug<int> GetBugById(int id)
        {
            return _mapper.Map<Bug<int>>(
                _unitOfWork.BugRepository.GetById(id));
        }

        public IEnumerable<Bug<int>> SearchBugs(string searchString)
        {
            return _mapper.Map<IEnumerable<Bug<int>>>(
                _unitOfWork.BugRepository.Search(searchString));
        }

        public IEnumerable<Bug<int>> GetBugsForProject(int projectId)
        {
            return _mapper.Map<IEnumerable<Bug<int>>>(
                _unitOfWork.BugRepository.GetBugsForProject(projectId));
        }

        public IEnumerable<Bug<int>> GetBugsForUser(int userId)
        {
            return _mapper.Map<IEnumerable<Bug<int>>>(
                _unitOfWork.BugRepository.GetBugsForUser(userId));
        }

        public Bug<int> AssignBugToUser(int bugId, int userId)
        {
            var bug = _unitOfWork.BugRepository.GetById(bugId);
            //bug.AssignToId = userId;
            //_unitOfWork.BugRepository.Update(bug);
            return _mapper.Map<Bug<int>>(bug);
        }
    }
}
