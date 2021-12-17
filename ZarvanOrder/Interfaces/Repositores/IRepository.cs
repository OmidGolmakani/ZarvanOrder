using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IRepository<TIdentity,TEntity> 
        where TEntity : class
        where TIdentity : struct
    {
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);
        void DeleteBatch(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void UpdateBatch(IEnumerable<TEntity> entities);
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> expression);
    }
}
