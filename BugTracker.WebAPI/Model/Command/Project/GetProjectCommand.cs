using System.ComponentModel.DataAnnotations;

namespace BugTracker.WebAPI.Model.Command.Project
{
    public class GetProjectCommand
    {
        [Required]
        public int ProjectId { get; set; }
    }
}
