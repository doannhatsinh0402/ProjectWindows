using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace QuanLySinhVien.Data.Infrastucture
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        // Marks an entity as modified
        void Update(TEntity entity);

        // Marks an entity to be removed
        void Delete(TEntity entity);

        //Delete multi records
      /*  void DeleteMulti(Expression<Func<TEntity, bool>> where);*/

        // Get an entity by int id
        TEntity GetSingleById(string id);

      /*  TEntity GetSingleByCondition(Expression<Func<TEntity, bool>> expression, string[] includes = null);*/
  

        IQueryable<TEntity> GetAll(string[] includes = null);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);

      /*  IQueryable<TEntity> GetMulti(Expression<Func<TEntity, bool>> predicate, string[] includes = null);*/

        /* IQueryable<TEntity> GetMultiPaging(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
 */
        int Count(Expression<Func<TEntity, bool>> where);

      /*  bool CheckContains(Expression<Func<TEntity, bool>> predicate);*/
    }
}
