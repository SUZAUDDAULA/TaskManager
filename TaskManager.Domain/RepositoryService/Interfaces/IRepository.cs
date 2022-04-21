using System;
using System.Collections.Generic;
using TaskManager.DAL.Entity;

namespace TaskManager.Domain.RepositoryService.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByFiltering(Func<T, bool> filter = null);
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
