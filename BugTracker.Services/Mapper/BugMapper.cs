using BugTracker.DataAccessLayer.Entities;
using DbEnums = BugTracker.DataAccessLayer.Entities.Enums;
using ModelEnums = BugTracker.DataModel.Enums;
using BugTracker.DataModel;

namespace BugTracker.Services.Mapper
{
    public static class BugMapper
    {
        public static Bug<TKey> ToModelEntity<TKey>(this BugEntity<TKey> bug)
        {
            return new Bug<TKey>()
            {
                Id = bug.Id,
                Name = bug.Name,
                AssignToId = bug.AssignToId,
                AuthorId = bug.AuthorId,
                Date = bug.Date,
                Description = bug.Description,
                Estimate = bug.Estimate,
                ProjectId = bug.ProjectId,
                Priority = (ModelEnums.BugPriority)bug.Priority,
                Status = (ModelEnums.BugStatus)bug.Status,
                Type = (ModelEnums.BugType)bug.Type,
            };
        }

        public static BugEntity<TKey> ToDbEntity<TKey>(this Bug<TKey> bug)
        {
            return new BugEntity<TKey>()
            {
                Id = bug.Id,
                Name = bug.Name,
                AssignToId = bug.AssignToId,
                AuthorId = bug.AuthorId,
                Date = bug.Date,
                Description = bug.Description,
                Estimate = bug.Estimate,
                ProjectId = bug.ProjectId,
                Priority = (DbEnums.BugPriority)bug.Priority,
                Status = (DbEnums.BugStatus)bug.Status,
                Type = (DbEnums.BugType)bug.Type,
            };
        }
    }
}
