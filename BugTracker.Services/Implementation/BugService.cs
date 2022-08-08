using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Bug<int>> GetBugById(int id)
        {
            var bug = await _unitOfWork.BugRepository.GetById(id);
            return _mapper.Map<Bug<int>>(bug);
        }

        public async IAsyncEnumerable<IAsyncEnumerable<Bug<int>>> SearchBugs(string searchString)
        {
            var users = await _unitOfWork.BugRepository.Search(searchString);
            yield return _mapper.Map<IAsyncEnumerable<Bug<int>>>(users);
        }

        public async IAsyncEnumerable<IAsyncEnumerable<Bug<int>>> GetBugsForProject(int projectId)
        {
            var users = await _unitOfWork.BugRepository.GetBugsForProject(projectId);
            yield return _mapper.Map<IAsyncEnumerable<Bug<int>>>(users);
        }

        public async IAsyncEnumerable<IAsyncEnumerable<Bug<int>>> GetBugsForUser(int userId)
        {
            var users = await _unitOfWork.BugRepository.GetBugsForUser(userId);
            yield return _mapper.Map<IAsyncEnumerable<Bug<int>>>(users);
        }

        public async Task<Bug<int>> AssignBugToUser(int bugId, int userId)
        {
            var bug = await _unitOfWork.BugRepository.GetById(bugId);
            bug.AssignToId = userId;
            // await ????
            _unitOfWork.BugRepository.Update(bug);
            return _mapper.Map<Bug<int>>(bug);
        }
    }
}
