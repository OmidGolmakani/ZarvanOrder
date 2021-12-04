using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Responses.Pageing;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface IGetService<TGetRequest, TGetsRequest, TResponse> where TGetRequest : class
                                                                       where TGetsRequest : class
                                                                       where TResponse : class
    {
        Task<TResponse> GetAsync(TGetRequest request);
        Task<ListResponse<TResponse>> GetsAsync(TGetsRequest request);
        Task<int> CountAsync(TGetsRequest request);
    }
}
