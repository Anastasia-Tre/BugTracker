using System.Collections.Generic;
using System.Linq;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using BugTracker.Services.Mapper;

namespace BugTracker.Services.Implementation
{
    public class BugService<TKey> : IBugService<TKey>
    {
        private readonly IUnitOfWork<TKey> _unitOfWork;

        public BugService(IUnitOfWork<TKey> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Bug<TKey> GetBugById(TKey id)
        {
            return _unitOfWork.BugRepository
                .GetById(id)
                .ToModelEntity();
        }

        public IEnumerable<Bug<TKey>> SearchBugs(string searchString)
        {
            return _unitOfWork.BugRepository
                .Search(searchString)
                .Select(bug => bug.ToModelEntity());
        }

        public IEnumerable<Bug<TKey>> GetBugsForProject(TKey projectId)
        {
            return _unitOfWork.BugRepository
                .GetBugsForProject(projectId)
                .Select(bug => bug.ToModelEntity());
        }

        public IEnumerable<Bug<TKey>> GetBugsForUser(TKey userId)
        {
            return _unitOfWork.BugRepository
                .GetBugsForUser(userId)
                .Select(bug => bug.ToModelEntity());
        }

        public void AssignBugToUser(Bug<TKey> bug, TKey userId)
        {
            bug.AssignToId = userId;
            _unitOfWork.BugRepository.Update(bug.ToDbEntity());
        }
    }
}
