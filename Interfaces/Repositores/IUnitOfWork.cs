using System;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
