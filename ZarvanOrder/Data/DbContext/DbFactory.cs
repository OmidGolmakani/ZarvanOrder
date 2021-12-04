using System;

namespace ZarvanOrder.Data.DbContext
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<AppDbContext> _instanceFunc;
        private Microsoft.EntityFrameworkCore.DbContext _dbContext;
        public Microsoft.EntityFrameworkCore.DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());
        public DbFactory(Func<AppDbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }
        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();

            }
        }
    }
}
