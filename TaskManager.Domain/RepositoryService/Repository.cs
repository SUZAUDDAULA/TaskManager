using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.DAL;
using TaskManager.DAL.Entity;
using TaskManager.Domain.RepositoryService.Interfaces;

namespace TaskManager.Domain.RepositoryService
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        private readonly TMDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(TMDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetByFiltering(Func<T, bool> filter = null)
        {
            if (filter is null) return entities.AsEnumerable();

            var filteredList = new List<T>();
            foreach (var entity in entities)
            {
                if (filter(entity))
                {
                    filteredList.Add(entity);
                }
            }

            return filteredList.AsEnumerable();
        }

    }
}
