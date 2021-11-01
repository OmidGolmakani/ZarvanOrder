﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface IService<TAddRequest,TEditRequest,TDeleteRequest,TResponse> where TAddRequest : class
                                                                                 where TEditRequest : class
                                                                                 where TDeleteRequest : class
                                                                                 where TResponse : class
    {
        Task<TResponse> Add(TAddRequest request);
        Task<TResponse> Update(TEditRequest request);
        Task<TResponse> Delete(TDeleteRequest request);
        Task BatchUpdate(IEnumerable<TDeleteRequest> request);
        Task<TResponse> BatchDelete(IEnumerable<TDeleteRequest> request);
    }
}
