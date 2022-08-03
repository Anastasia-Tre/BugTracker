using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    public class BugService<TKey> : IBugService<TKey>
    {
        public Bug<TKey> GetBugById(TKey id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bug<TKey>> SearchBugs(string searchString)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bug<TKey>> GetBugsForProject(TKey projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bug<TKey>> GetBugsForUser(TKey userId)
        {
            throw new NotImplementedException();
        }

        public bool AssignBugToUser(Bug<TKey> bug, TKey userId)
        {
            throw new NotImplementedException();
        }
    }
}
