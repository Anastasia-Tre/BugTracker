using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.WebAPI.Model.Response.Project
{
    public class ProjectsResponse
    {
        public List<Project<int>> Projects { get; set; }
    }
}
