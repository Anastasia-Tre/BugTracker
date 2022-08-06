using System.ComponentModel.DataAnnotations;

namespace BugTracker.WebAPI.Model.Command.Bug
{
    public class GetBugsForUserCommand
    {
        [Required] public int UserId { get; set; }
    }
}
