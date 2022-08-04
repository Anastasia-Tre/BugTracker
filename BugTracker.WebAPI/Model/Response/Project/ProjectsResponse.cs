using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.WebAPI.Model.Response.Project
{
    public class ProjectsResponse
    {
        public IEnumerable<Project<int>> Projects { get; set; }
    }
}
