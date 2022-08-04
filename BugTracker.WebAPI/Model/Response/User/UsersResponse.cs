using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.WebAPI.Model.Response.User
{
    public class UsersResponse
    {
        public IEnumerable<User<int>> Users { get; set; }
    }
}
