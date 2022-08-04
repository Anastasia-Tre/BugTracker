﻿using System.Collections.Generic;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFRepository<T> : IRepository<T, int> where T : BaseEntity<int>
    {
        protected readonly BugTrackerDbContext _dbContext;
        protected readonly DbSet<T> _entities;

        public EFRepository(BugTrackerDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _entities = dbSet;
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsNoTracking();
        }
    }
}
