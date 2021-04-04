using System.Collections.Generic;
using TaskManager.DAL.Entity;

namespace TaskManager.Domain.RepositoryService.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
