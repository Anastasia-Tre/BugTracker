using System;
using BugTracker.DataModel.Enums;

namespace BugTracker.DataModel;

public class Task<TKey>
{
    public TKey Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public TaskStatus Status { get; set; }
    public TaskType Type { get; set; }
    public TaskPriority Priority { get; set; }
    public int Difficulty { get; set; }

    public TKey AssignToId { get; set; }
    public User<TKey> AssignTo { get; set; }

    public TKey AuthorId { get; set; }
    public User<TKey> Author { get; set; }

    public TKey ProjectId { get; set; }
    public Project<TKey> Project { get; set; }

    public DateTime Deadline { get; set; }
    public float Estimate { get; set; }
}
