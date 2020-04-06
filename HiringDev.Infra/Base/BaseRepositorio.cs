using HiringDev.IRepositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HiringDev.Infra.Contexto;
using HiringDev.Util.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HiringDev.Infra.Base
{
    public class BaseRepositorio<T> : IBaseRepositorio<T>, IDisposable where T : class
    {

        protected DatabaseContext _ctx;

        public BaseRepositorio(DatabaseContext ctx)
        {
            
            _ctx = ctx;
        }

        protected BaseRepositorio()
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(@"Server=DESKTOP-62S01SF\SQLEXPRESS2016;Database=Youtube;Persist Security Info=True;User ID=sa;Password=Teste@123");
            _ctx = new DatabaseContext(options.Options);
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public void Delete(int key)
        {
            var entity = _ctx.Set<T>().Find(key);
            _ctx.Remove(entity);
        }

        public void DeleteRange(IList<T> entities)
        {
            _ctx.RemoveRange(entities);
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();

            GC.SuppressFinalize(this);
        }
        public T First(Expression<Func<T, bool>> predicate, params string[] entities)
        {
            var query = _ctx.Set<T>().Where(predicate);
            foreach (var include in entities)
                query = query.Include(include);

            return query.FirstOrDefault();
        }

        public T FirstNoTracking(Expression<Func<T, bool>> predicate, params string[] entities)
        {
            var query = _ctx.Set<T>().Where(predicate).AsNoTracking();
            foreach (var include in entities)
                query = query.Include(include);

            return query.FirstOrDefault();
        }

        public T GetById(long key, params string[] entities)
        {
            var query = _ctx.Set<T>().Find(key);
            foreach (string include in entities)
                _ctx.Entry(query).Reference(include).Load();

            return _ctx.Set<T>().Find(key);
        }

        public T GetById(int key, params string[] entities)
        {
            var query = _ctx.Set<T>().Find(key);
            foreach (string include in entities)
                _ctx.Entry(query).Reference(include).Load();

            return _ctx.Set<T>().Find(key);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params string[] entities)
        {
            var query = _ctx.Set<T>().Where(predicate);
            foreach (var include in entities)
                query = query.Include(include);

            return query;
        }

        public IQueryable<T> GetNoTracking(Expression<Func<T, bool>> predicate, params string[] entities)
        {
            var query = _ctx.Set<T>().Where(predicate);
            foreach (var include in entities)
                query = query.Include(include);

            return query.AsNoTracking();
        }

        public IQueryable<T> GetAll(params string[] entities)
        {
            var query = _ctx.Set<T>().AsQueryable();
            foreach (var include in entities)
                query = query.Include(include);

            return query;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAllNoTracking()
        {
            return _ctx.Set<T>().AsNoTracking();
        }

        public void Insert(T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
