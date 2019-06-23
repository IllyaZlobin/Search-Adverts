using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace berloga.Models.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected berlogaContext BerlogaContext { get; set; }

        public BaseRepository(berlogaContext berlogaContext)
        {
            this.BerlogaContext = berlogaContext;
        }

        public IQueryable<T> findAll()
        {
            return this.BerlogaContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.BerlogaContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.BerlogaContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.BerlogaContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.BerlogaContext.Set<T>().Remove(entity);
        }
    }
}