using System;
using BugTracker.DataModel.Enums;

namespace BugTracker.DataModel
{
    public class Bug<TKey>
    {
        public TKey Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public BugStatus Status { get; set; }
        public BugType Type { get; set; }
        public BugPriority Priority { get; set; }
        
        public TKey AssignToId { get; set; }
        public TKey ProjectId { get; set; }

        public DateTime Date { get; set; }
        public float Estimate { get; set; }
    }
}
