using System;
using BugTracker.DataAccessLayer.Entities.Enums;
using BugTracker.Models;

namespace BugTracker.DataAccessLayer.Entities
{
    public class BugEntity<TKey> : BaseEntity<TKey>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public BugStatus Status { get; set; }
        public BugType Type { get; set; }
        public BugPriority Priority { get; set; }

        public TKey AuthorId { get; set; }
        public UserEntity Author { get; set; }

        public TKey AssignToId { get; set; }
        public UserEntity AssignTo { get; set; }
        
        public TKey ProjectId { get; set; }
        public ProjectEntity Project { get; set; }

        public DateTime Date { get; set; }
        public float Estimate { get; set; }
    }
}
