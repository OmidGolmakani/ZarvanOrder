﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Delete(T entity);
        void DeleteBatch(IEnumerable<T> entities);
        T Update(T entity);
        void UpdateBatch(IEnumerable<T> entities);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
    }
}