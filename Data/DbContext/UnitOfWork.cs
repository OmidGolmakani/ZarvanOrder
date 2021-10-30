using System;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Repositores;

namespace ZarvanOrder.Data.DbContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;
        public UnitOfWork(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
