using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;

namespace ZarvanOrder.Repositores
{
    public class Repository<T> : IRepository<T> where T : class, Interfaces.Entites.IAuditEntity,
                                                                 Interfaces.Entites.IDeleteEntity
    {
        private readonly DbFactory _dbFactory;
        private readonly Mapper _mapper;
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }
        public Repository(DbFactory dbFactory,
                          AutoMapper.Mapper mapper)
        {
            _dbFactory = dbFactory;
            this._mapper = mapper;
        }
        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public virtual T Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            return DbSet.Add(entity).Entity;
        }

        public virtual T Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            return DbSet.Update(entity).Entity;
        }

        public virtual IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking();
        }

        public virtual T Update(T entity)
        {
            entity.LastModified = DateTime.Now;
            return DbSet.Update(entity).Entity;
        }

        public virtual void UpdateBatch(System.Collections.Generic.IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.LastModified = DateTime.Now;
            }
            DbSet.UpdateRange(entities);
        }

        public virtual long Count(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).AsNoTracking().Count();
        }

        public virtual void DeleteBatch(System.Collections.Generic.IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
            }
            DbSet.RemoveRange(entities);
        }
    }
}
