using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HiringDev.IRepositorio.Base
{
    public interface IBaseRepositorio<T> where T : class
    {
        IQueryable<T> GetAllNoTracking();
        IQueryable<T> GetAll(params string[] entities);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params string[] entities);
        IQueryable<T> GetNoTracking(Expression<Func<T, bool>> predicate, params string[] entities);
        T GetById(int key, params string[] entities);
        T GetById(long key, params string[] entities);
        T First(Expression<Func<T, bool>> predicate, params string[] entities);
        T FirstNoTracking(Expression<Func<T, bool>> predicate, params string[] entities);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int key);
        void DeleteRange(IList<T> entities);
        void Commit();
        void Dispose();
    }
}
