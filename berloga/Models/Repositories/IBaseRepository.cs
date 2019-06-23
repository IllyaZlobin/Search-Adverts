using System;
using System.Linq;
using System.Linq.Expressions;

namespace berloga.Models.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> findAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}