using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IBugService<TKey>
    {
        // public Bug<TKey> CreateBug();
        public Task<Bug<int>> GetBugById(TKey id);
        public Task<IEnumerable<Bug<int>>> SearchBugs(string searchString);
        public Task<IEnumerable<Bug<int>>> GetBugsForProject(TKey projectId);
        public Task<IEnumerable<Bug<int>>> GetBugsForUser(TKey userId);

        public Task<Bug<int>> AssignBugToUser(int bugId, TKey userId);
    }
}
