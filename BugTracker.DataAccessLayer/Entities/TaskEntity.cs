using System;
using BugTracker.DataAccessLayer.Entities.Enums;

namespace BugTracker.DataAccessLayer.Entities;

public class TaskEntity<TKey> : BaseEntity<TKey>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public TaskStatus Status { get; set; }
    public TaskType Type { get; set; }
    public TaskPriority Priority { get; set; }
    public int Difficulty { get; set; }

    public TKey AssignedId { get; set; }
    //public UserEntity<TKey> Assigned { get; set; }

    public TKey AuthorId { get; set; }
    //public UserEntity<TKey> Author { get; set; }

    public TKey ProjectId { get; set; }
    //public ProjectEntity<TKey> Project { get; set; }

    public DateTime Deadline { get; set; }
    //public float Estimate { get; set; }
}
