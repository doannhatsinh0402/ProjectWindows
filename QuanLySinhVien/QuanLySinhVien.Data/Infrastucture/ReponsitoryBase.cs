using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace QuanLySinhVien.Data.Infrastucture
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly IDbSet<TEntity> dbSet;

        public RepositoryBase(DbContext context)
        {
            this.Context = context;
            this.dbSet = Context.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual TEntity GetSingleById(string id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }


        public virtual int Count(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Count(where);
        }
        public IQueryable<TEntity> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = Context.Set<TEntity>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return Context.Set<TEntity>().AsQueryable();
        }

    }
}
