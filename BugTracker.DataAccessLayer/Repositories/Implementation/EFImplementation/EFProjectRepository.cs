﻿using System.Collections.Generic;
using System.Linq;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFProjectRepository<TKey> : EFRepository<ProjectEntity<TKey>, TKey>, IProjectRepository<TKey>
    {
        public EFProjectRepository(BugTrackerDbContext<TKey> dbContext) : base(dbContext, dbContext.Projects)
        {
        }

        public IEnumerable<ProjectEntity<TKey>> Search(string searchString = "")
        {
            var result = GetAll();
            var isSearchStringEmpty = string.IsNullOrEmpty(searchString);

            if (!isSearchStringEmpty)
            {
                searchString = searchString.ToLower();
                result = result.Where(project =>
                    project.Name.ToLower().Contains(searchString)
                    || project.Description.Contains(searchString));
            }

            return result.OrderBy(project => project.Name);
        }
    }
}