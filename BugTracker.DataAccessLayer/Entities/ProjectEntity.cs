using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.DataAccessLayer.Entities
{
    public class ProjectEntity<TKey> : BaseEntity<TKey>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
