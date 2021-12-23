using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Model.Dtos.Responses.Customers;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface ICustomerService : IService<AddCustomerRequest, EditCustomerRequest, DeleteCustomerRequest, CustomerResponse>,
                                        IGetService<GetCustomerRequest, GetCustomersRequest, CustomerResponse>
    {
    }
}
