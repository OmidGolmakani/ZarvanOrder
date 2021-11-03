using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;

namespace ZarvanOrder.Services.Data
{
    public class Service<TAddRequest, TEditRequest, TDeleteRequest, TResponse> :
                 IService<TAddRequest, TEditRequest, TDeleteRequest, TResponse> where TAddRequest : class
                                                                                where TEditRequest : class
                                                                                where TDeleteRequest : class
                                                                                where TResponse : class


    {
        public Service()
        {
        }

        public Task<TResponse> Add(TAddRequest request)
        {
            throw new NotImplementedException();
        }

        public Task BatchDelete(IEnumerable<TDeleteRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task BatchUpdate(IEnumerable<TEditRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TDeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> Update(TEditRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
