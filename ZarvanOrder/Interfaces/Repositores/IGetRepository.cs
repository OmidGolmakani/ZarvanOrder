using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IGetRepository<TGetRequest, TGetsRequest, TResponse>
    {
        Task<TResponse> GetById(TGetRequest request, bool includeDeleted = false);
        IQueryable<TResponse> Get(TGetsRequest request, bool includeDeleted = false);
    }
}
