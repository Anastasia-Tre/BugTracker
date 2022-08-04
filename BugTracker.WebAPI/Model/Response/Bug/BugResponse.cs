using BugTracker.DataModel;

namespace BugTracker.WebAPI.Model.Response.Bug
{
    public class BugResponse
    {
        public Bug<int> Bug { get; set; }
    }
}
