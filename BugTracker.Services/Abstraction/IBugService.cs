using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IBugService<TKey>
    {
        // public Bug<TKey> CreateBug();
        public Bug<TKey> GetBugById(TKey id);
        public IEnumerable<Bug<TKey>> SearchBugs(string searchString);
        public IEnumerable<Bug<TKey>> GetBugsForProject(TKey projectId);
        public IEnumerable<Bug<TKey>> GetBugsForUser(TKey userId);

        public Bug<TKey> AssignBugToUser(int bugId, TKey userId);
    }
}
