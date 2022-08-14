using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IBugService<TKey>
    {
        // public Bug<TKey> CreateBug();
        public Task<Bug<TKey>> GetBugById(TKey id);

        public Task<IEnumerable<Bug<TKey>>>
            SearchBugs(string searchString = "");

        public Task<IEnumerable<Bug<TKey>>> GetBugsForProject(TKey projectId);
        public Task<IEnumerable<Bug<TKey>>> GetBugsForUser(TKey userId);

        public Task<Bug<TKey>> AssignBugToUser(TKey bugId, TKey userId);
    }
}
