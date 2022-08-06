using System.ComponentModel.DataAnnotations;

namespace BugTracker.WebAPI.Model.Command.Bug
{
    public class GetBugsForProjectCommand
    {
        [Required] public int ProjectId { get; set; }
    }
}
