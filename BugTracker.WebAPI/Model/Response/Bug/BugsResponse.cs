using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.WebAPI.Model.Response.Bug
{
    public class BugsResponse
    {
        public IEnumerable<Bug<int>> Bugs { get; set; }
    }
}
