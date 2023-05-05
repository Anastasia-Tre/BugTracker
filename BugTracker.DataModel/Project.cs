using System;
using BugTracker.DataModel.Enums;

namespace BugTracker.DataModel;

public class Project<TKey>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public ProjectStatus Status { get; set; }

    public TKey AuthorId { get; set; }
    //public User<TKey> Author { get; set; }

    //public Task<TKey>[] Tasks { get; set; }
    //public User<TKey>[] Team { get; set; }
}
