using System.Collections.Generic;

namespace WebApi.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Insert(T entity);
        int Update(T entity);
        void Delete(T entity);
        T GetById(int id, params string[] navigationProperties);
        List<T> GetAll<TEntity>(params string[] navigationProperties);
    }
}
