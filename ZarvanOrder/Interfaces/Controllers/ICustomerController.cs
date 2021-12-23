using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Customers;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface ICustomerController: IController<AddCustomerRequest, EditCustomerRequest, DeleteCustomerRequest>,
                                          IGetController<GetCustomerRequest, GetCustomersRequest>
    {
        
    }
}
