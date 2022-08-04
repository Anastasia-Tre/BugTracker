using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.WebAPI.Model.Response.Bug
{
    public class BugsResponse
    {
        public List<Bug<int>> Bugs { get; set; }
    }
}
